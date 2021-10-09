using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Bullet : MonoBehaviour , PooledObject
    {
        private Rigidbody2D _rb;
        
        [SerializeField] private float _bulletSpeed = 2500f;
        [SerializeField] private int _damage = 10;

        [SerializeField] private float _timeToUnUse;
        [SerializeField] private float _timeToDestroy = 10f;
        private float _timerToDestroy;
        public GameObjectPooler GameObjectPooler { get; set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            Restart();
        }

        private void Update()
        {
            _timerToDestroy -= Time.deltaTime;

            
            if (_timerToDestroy <= 0)
                DestroyObject();
            

            _rb.velocity =transform.up * (_bulletSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                StartCoroutine(DestroyBullet());
            }
            else if (other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                StartCoroutine(DestroyBullet());
                other.GetComponent<Character>().LoseHealth(_damage);
            }
        }

        IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(_timeToUnUse);
            DestroyObject();
        }

        public void Restart()
        {
            _timerToDestroy = _timeToDestroy;
        }

        public void DestroyObject()
        {
            GameObjectPooler.ReturnToPool(gameObject);
        }
    }
}

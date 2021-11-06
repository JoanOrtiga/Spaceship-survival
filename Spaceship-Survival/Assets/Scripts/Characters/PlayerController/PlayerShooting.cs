using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SpaceShipSurvival
{

    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObjectPooler _gameObjectPoolerPrefab;
        
        private GameObject _activeBullet;
        
        [SerializeField] private float _timeBetweenBullets;
        private float _betweenBulletsTimer;

        [Header("Reloading")]
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _magazineCapacity = 30;
        private int _currentMagazine;

        private bool _reloading = false;
        [SerializeField] private KeyCode _reloadButton = KeyCode.R;
        
        private void Awake()
        {
            _gameObjectPoolerPrefab = Instantiate(_gameObjectPoolerPrefab, SceneReferences.Instance.InstanciatedObjectsParent);
            _currentMagazine = _magazineCapacity;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_reloadButton))
            {
                StartCoroutine(Reloading());
            }
            
            if (_betweenBulletsTimer >= 0)
            {
                _betweenBulletsTimer -= Time.deltaTime;
            }
            else if (Input.GetMouseButton(0) && !_reloading)
            {
                _activeBullet = _gameObjectPoolerPrefab.GetPooledObject();
                
                _activeBullet.GetComponent<PooledObject>().Restart();
                _activeBullet.transform.position = transform.position;
                _activeBullet.transform.rotation = transform.rotation;
                _activeBullet.SetActive(true);

                _betweenBulletsTimer = _timeBetweenBullets;
                _currentMagazine--;

                if (_currentMagazine <= 0)
                {
                    StartCoroutine(Reloading());
                }
            }
        }

        IEnumerator Reloading()
        {
            _reloading = true;

            yield return new WaitForSeconds(_reloadTime);

            _currentMagazine = _magazineCapacity;
            _reloading = false;
        }
    }
}

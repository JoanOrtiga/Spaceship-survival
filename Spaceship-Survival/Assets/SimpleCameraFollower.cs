using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class SimpleCameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField, Range(0.0f, 1.0f)] private float _speed;

        public event Action act;
        public Action act2;

        private void Awake()
        {
            _player.GetComponent<PlayerController>().OnPlayerDead += PlayerDead;
        }

        private void PlayerDead()
        {
            _player.GetComponent<PlayerController>().OnPlayerDead -= PlayerDead;
            this.enabled = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 position =  Vector3.Lerp(transform.position, _player.position, _speed);
            position.z = transform.position.z;

            transform.position = position;
        }
    }
}

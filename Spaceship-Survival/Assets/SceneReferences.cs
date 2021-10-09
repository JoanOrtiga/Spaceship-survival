using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class SceneReferences : MonoBehaviour
    {
        private static SceneReferences _instance;
        public static SceneReferences Instance => _instance;


        [SerializeField] private Transform _player;
        public Transform Player => _player;
        
        [SerializeField] private Transform _instanciatedObjectsParent;
        public Transform InstanciatedObjectsParent => _instanciatedObjectsParent;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                return;
            }
            
            Destroy(gameObject);
        }
    }
}

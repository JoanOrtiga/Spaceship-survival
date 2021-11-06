using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class SceneReferences : MonoBehaviour
    {
        private static SceneReferences _instance;
        public static SceneReferences Instance
        {
            get
            {
                if (_instance is null)
                {
                    SceneReferences references = FindObjectOfType<SceneReferences>();
                    
                    if (references != null)
                    {
                        _instance = references;
                        return _instance;
                    }
                    
                    GameObject sceneReferences = new GameObject();
                    _instance = sceneReferences.AddComponent<SceneReferences>();
                }

                return _instance;
            }
            private set
            {
                if (_instance != null)
                {
                    Destroy(value);
                    return;
                }

                _instance = value;
            }
        }


        [SerializeField] private Transform _player;
        public Transform Player => _player;
        
        [SerializeField] private Transform _instanciatedObjectsParent;
        public Transform InstanciatedObjectsParent => _instanciatedObjectsParent;

        private void Awake()
        {
            Instance = this;
        }
    }
}

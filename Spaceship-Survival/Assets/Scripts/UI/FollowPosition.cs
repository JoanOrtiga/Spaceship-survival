using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class FollowPosition : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Start()
        {
            transform.parent = SceneReferences.Instance.InstanciatedObjectsParent;
        }

        private void Update()
        {
            transform.position = target.position;
        }
    }
}

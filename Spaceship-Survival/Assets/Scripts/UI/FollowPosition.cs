using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class FollowPosition : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Awake()
        {
            transform.parent = null;
        }

        private void Update()
        {
            transform.position = target.position;
        }
    }
}

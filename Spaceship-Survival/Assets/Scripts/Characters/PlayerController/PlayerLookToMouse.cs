using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceShipSurvival
{
    public class PlayerLookToMouse : MonoBehaviour
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.up = (mousePosition-(Vector2)transform.position).normalized;
        }
    }   
}
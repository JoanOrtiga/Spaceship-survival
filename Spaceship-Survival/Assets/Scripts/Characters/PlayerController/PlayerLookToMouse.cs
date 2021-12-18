using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceShipSurvival
{
    public class PlayerLookToMouse : MonoBehaviour , PauseableObject
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
            GameController.Instance.OnGamePaused += Pause;
        }

        private void Update()
        {
            if (GameController.Instance.IsGamePaused())
                return;
            
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.up = (mousePosition-(Vector2)transform.position).normalized;
        }

        private void OnDestroy()
        {
            GameController.Instance.OnGamePaused += Pause;
        }

        public void Pause(bool paused)
        {
            this.enabled = !paused;
        }
    }   
}
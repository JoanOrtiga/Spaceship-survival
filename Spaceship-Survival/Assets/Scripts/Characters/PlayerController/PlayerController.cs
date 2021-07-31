using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class PlayerController : Character
    {
        private Rigidbody2D rigidbody2D;
        [SerializeField] private float movementSpeed = 30.0f;

        private float inputX;
        private float inputY;
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            rigidbody2D.AddForce(new Vector2(inputX, inputY) * (Time.deltaTime * movementSpeed), ForceMode2D.Impulse);
        }
    }
}
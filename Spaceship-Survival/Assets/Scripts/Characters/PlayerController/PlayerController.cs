using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class PlayerController : Character
    {
        private Rigidbody2D rb2d;
        [SerializeField] private float movementSpeed = 30.0f;

        private float inputX;
        private float inputY;

        protected override void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            rb2d.AddForce(new Vector2(inputX, inputY) * (Time.deltaTime * movementSpeed), ForceMode2D.Impulse);
        }
    }
}
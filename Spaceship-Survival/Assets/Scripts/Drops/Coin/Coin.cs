using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Coin : MonoBehaviour
    {
        private Transform coinCotroller;
        [SerializeField] int valueCoin = 1;
        bool triggerCalled = false;

        private void Start()
        {
            transform.parent = SceneReferences.Instance.InstanciatedObjectsParent;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && triggerCalled==false)
            {
                PlayerStats.Instance.AddCoins(valueCoin);
                triggerCalled = true;
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
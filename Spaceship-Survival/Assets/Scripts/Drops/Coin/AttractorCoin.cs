using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class AttractorCoin : MonoBehaviour
    {
        [SerializeField] float attractorSpeed = 5;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                transform.parent.position = Vector2.MoveTowards(transform.position, other.transform.position, attractorSpeed*Time.deltaTime);
            }
        }
    }
}
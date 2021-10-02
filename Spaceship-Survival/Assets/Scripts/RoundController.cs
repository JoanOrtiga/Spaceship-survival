using System;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShipSurvival
{
    public class RoundController : MonoBehaviour
    {
        public static RoundController Instance;

        public Action<bool> RoundChangeState { get; set; }


        [Header("Debug")] 
        public bool roundState;

        private void Awake()
        {
            Instance = this;
        }

        private void OnValidate()
        {
            if(RoundChangeState != null)
                RoundChangeState.Invoke(roundState);
        }

        private void StartRound()
        {
            RoundChangeState.Invoke(true);
        }
        
        private void FinishRound()
        {
            RoundChangeState.Invoke(false);
        }
        
    }
}
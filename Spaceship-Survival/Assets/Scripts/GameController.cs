using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceShipSurvival
{
    public class GameController : MonoBehaviour
    {
        private bool gamePaused = false;

        private SpaceShipLogic logic;
        

        public bool GetGamePaused()
        {
            return gamePaused;
        }
        
        public void SetGamePause(bool paused)
        { 
            gamePaused = paused;
            Time.timeScale = paused ? 0.0f : 1.0f;
        }

        private void Awake()
        {
            logic = SpaceShipLogic.GetLogic();
            logic.GetRoundsData();
        }
    }
}

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

        private static GameController _instance;

        public static GameController Instance
        {
            get
            {
                if (_instance is null)
                {
                    GameController stats = FindObjectOfType<GameController>();
                    
                    if (stats != null)
                    {
                        _instance = stats;
                        return _instance;
                    }
                    
                    GameObject playerStats = new GameObject();
                    GameController._instance = playerStats.AddComponent<GameController>();
                }

                return _instance;
            }
            private set
            {
                if (_instance != null)
                {
                    Destroy(value);
                    return;
                }

                _instance = value;
            }
        }
        
        public event Action<bool> OnGamePaused;
        
        private void Awake()
        {
            logic = SpaceShipLogic.GetLogic();
            logic.GetRoundsData();

            Instance = this;
        }

        public bool IsGamePaused()
        {
            return gamePaused;
        }
        
        public void SetGamePause(bool paused)
        { 
            gamePaused = paused;
            Time.timeScale = paused ? 0.0f : 1.0f;
            OnGamePaused?.Invoke(gamePaused);
        }
    }
}

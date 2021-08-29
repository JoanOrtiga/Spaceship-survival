using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class SpaceShipLogic : MonoBehaviour
    {
        static SpaceShipLogic Instance;

        private RoundsData roundsData;

        public Character player;
        
        public static SpaceShipLogic GetLogic()
        {
            if (Instance == null)
            {
                GameObject spaceShipLogicGO = new GameObject();
                Instance = spaceShipLogicGO.AddComponent<SpaceShipLogic>();
                spaceShipLogicGO.name = "SpaceShipLogic";
                DontDestroyOnLoad(spaceShipLogicGO);
                
                Instance.Init();
            }

            return Instance;
        }

        public void Init()
        {
           /* roundsData = Resources.Load("RoundsData") as RoundsData;
            if(roundsData == null)
                Debug.LogError("Rounds data couldn't be loaded");*/

            player = FindObjectOfType<PlayerController>().GetComponent<Character>();
        }

        public RoundsData GetRoundsData()
        {
            return roundsData;
        }
    }
}


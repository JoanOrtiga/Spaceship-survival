using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceShipSurvival
{

    [CreateAssetMenu(fileName = "Drops", menuName = "Character/Drops")]
    public class DropData : ScriptableObject
    {
        public List<Drop> drops = new List<Drop>();

        //Coins
        public int minCoinsDrop = 3;
        public int maxCoinsDrop = 10;
        public GameObject coin;
        [SerializeField] private float _coinRange = 3;
        private int randomCoins;
        private Vector2 coinPosition;

        public void Drop(Vector3 position)
        {
            
            GameObject drop = GetRandomDrop();

            if (drop != null)
                Instantiate(drop, position, Quaternion.identity);

            //Coin
            if (minCoinsDrop < maxCoinsDrop)
            {
                randomCoins = Convert.ToInt32(Random.Range(minCoinsDrop, maxCoinsDrop));
                for (int i = 0; i < randomCoins; i++)
                {
                    coinPosition = Random.insideUnitCircle * _coinRange + (Vector2)position;
                    Instantiate(coin, coinPosition, Quaternion.identity);
                }
            }
        }

        private GameObject GetRandomDrop()
        {
            float addedChances = 0;
            float random = Random.Range(0.1f, 100.0f);

            for (int i = 0; i < drops.Count; i++)
            {
                if (random < drops[i].dropChance + addedChances && random > addedChances)
                {
                    return drops[i].drop;
                }

                addedChances += drops[i].dropChance;
            }

            return null;
        }
    }

    [System.Serializable]
    public class Drop
    {
        public float dropChance = 0;
        public GameObject drop;
    }
    
    [CustomEditor(typeof(DropData))]
    public class CustomDropData : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DropData dropData = (target as DropData);

            float add = 0;
            for (int i = 0; i < dropData.drops.Count; i++)
            {
                add += dropData.drops[i].dropChance;
            }

            if (add > 100)
                EditorGUILayout.HelpBox("Total chances > 100", MessageType.Error);


            if (dropData.minCoinsDrop > dropData.maxCoinsDrop)
            {
                EditorGUILayout.HelpBox("Min Coins Drop > Max Coins Drop", MessageType.Error);
            }
        }
    }
}

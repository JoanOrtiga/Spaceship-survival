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

        public void Drop(Vector3 position)
        {
            GameObject drop = GetRandomDrop();
            if(drop != null) 
                Instantiate(drop, position, Quaternion.identity);
        }

        private GameObject GetRandomDrop()
        {
            float addedChances = 0;
            float random = Random.Range(0.1f, 100.0f);
            for (int i = 0; i < drops.Count; i++)
            {
                if(random < drops[i].dropChance+addedChances && random > addedChances)
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
            
            if(add > 100)
                EditorGUILayout.HelpBox("Total chances > 100", MessageType.Error);
        }   
    }
}

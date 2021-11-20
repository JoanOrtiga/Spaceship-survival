using System;
using UnityEngine;

[Serializable]
public abstract class Upgrade : ScriptableObject
{
    public Sprite icon;
    public ValuePerCostUpgrade[] values;
    public abstract void Upgrading();
}

[Serializable]
public class ValuePerCostUpgrade
{
    public float increaseValue;
    public int price;
}
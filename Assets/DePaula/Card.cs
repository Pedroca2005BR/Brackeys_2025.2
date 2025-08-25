using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    [TextArea] public string description;

    //[Header("Upgrade Variables")]
    //public int maxLevel;
    //public int currentLevel = 0;

    [Header("Special Card")]
    public bool isSpecialCard;


    public bool CanBeGenerated()
    {
        return true;
    }
}

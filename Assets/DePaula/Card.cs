using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    [TextArea] public string description;
    public Sprite backgroundImage;

    public TipoCarta tipo;

    [Header("Upgrade Card")]
    //public int maxLevel;
    //public int currentLevel = 0;
    public Upgrades.TipoUpgrade tipoUpgrade;

    //[Header("Special Card")]
    //public bool isSpecialCard;

    [Header("Cookie Card")]
    public int waveBudget;


    public bool CanBeGenerated()
    {
        switch(tipo)
        {
            case TipoCarta.Normal:
                if (Upgrades.instance.IsAtMaxLevel(tipoUpgrade))
                {
                    return false;
                }
                return true;

            // Falta cases pra special
            default:
                return true;
        }
    }

    public enum TipoCarta
    {
        Normal = 0,
        Special = 1,
        Cookie = 2
    }
}

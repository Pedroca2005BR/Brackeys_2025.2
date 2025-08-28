using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private void Start()
    {
        Upgrade("Dash");
    }
    void Upgrade(string algo)
    {
        switch(algo)
        {
            case "Dash":
                
                break;

            case "Bow":
                
                break;

            case "Health":
                
                break;

            case "Damage":
                
                break;

            default:
                Debug.Log("Upgrade desconhecido: " + algo);
                break;
        }

    }
        
}

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
                PlayerPrefs.SetInt("Dash", 1);
                break;

            case "Bow":
                PlayerPrefs.SetInt("Bow", 1);
                break;

            case "Health":
                float currentHealth = PlayerPrefs.GetFloat("MaxHealth", 100f);
                currentHealth += 20f; // aumenta a vida maxima em 20
                PlayerPrefs.SetFloat("MaxHealth", currentHealth);
                PlayerPrefs.SetFloat("CurrentHealth", currentHealth); // restaura a vida atual para a nova vida maxima
                break;

            case "Damage":
                float currentDamage = PlayerPrefs.GetFloat("Damage", 10f);
                currentDamage += 5f; // aumenta o dano em 5
                PlayerPrefs.SetFloat("Damage", currentDamage);
                break;

            default:
                Debug.Log("Upgrade desconhecido: " + algo);
                break;
        }

    }
        
}

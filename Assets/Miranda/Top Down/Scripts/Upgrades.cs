using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class Upgrades : MonoBehaviour
{
    playerMovement playerMovement;
    Vida vida;
    //public Projectile projectile;




    private int dashLevel = 0, healthLevel, damageLevel, speedLevel, projectileCooldownLevel;


    public TipoUpgrade tipoUpgrade;
    public enum TipoUpgrade
    {
        Dash,
        Health,
        Damage,
        Speed,
        ProjectileCooldown
    };
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Upgrade(tipoUpgrade.ToString());
            Debug.Log("Upgrade: " + tipoUpgrade.ToString());
        }
    }

    void Start()
    {
        playerMovement= GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        //projectile = GetComponent<Projectile>();
    }


    //Chamar essa função quando o player aperta a carta desejada e olhar no inspetor para qual tipo de upgrade ele quer
    public void Upgrade(string tipo)
    {
        switch (tipo)
        {
            case "Dash":
                if (dashLevel < 3)
                {
                    dashLevel++;
                    playerMovement.atualizarDash(dashLevel);
                }
                else Debug.Log("Dash passou do nivel: " + dashLevel);
                    break;

            case "Speed":
                if (speedLevel < 3)
                {
                    speedLevel++;
                    playerMovement.atualizarMoveSpeed(speedLevel);
                }
                else Debug.Log("Speed passou do nivel: " + speedLevel);

                break;

            case "MaxHealth":
                if (healthLevel < 3)
                {
                    healthLevel++;
                    vida.atualizarVida(healthLevel);
                }
                break;

            case "Damage":
                if (damageLevel < 3)
                {
                    damageLevel++;
                    playerMovement.atualizarMoveSpeed(damageLevel);
                }
                break;

            case "ProjectileCooldown":
                if (projectileCooldownLevel < 3)
                {
                    projectileCooldownLevel++;
                    playerMovement.atualizarMoveSpeed(projectileCooldownLevel);
                }
                break;
        }
    }

    public void Reset()
    {
        //PlayerMovement.cs
        playerMovement.atualizarDash(0);
        dashLevel = 0;
        playerMovement.atualizarMoveSpeed(0);
        speedLevel = 0;

        //Vida.cs
        playerMovement.atualizarMoveSpeed(0);
        healthLevel = 0;

        //Projectile.cs
    }


}

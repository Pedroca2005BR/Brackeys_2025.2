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
    //public GameObject teste;

    #region Singleton

    public static Upgrades instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    #endregion




    //private int dashLevel = 0, healthLevel = 0, damageLevel = 0, speedLevel = 0, projectileCooldownLevel = 0;
    private int[] currentLevels;
    [Tooltip("Order: Dash - Health - Damage - Speed - ShootSpeed")]
    public int[] maxLevels;


    //public TipoUpgrade tipoUpgrade;
    public enum TipoUpgrade
    {
        Dash = 0,
        Health = 1,
        Damage = 2,
        Speed = 3,
        ProjectileCooldown = 4
    };
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.U))
    //    {
    //        Upgrade(tipoUpgrade.ToString());
    //        Debug.Log("Upgrade: " + tipoUpgrade.ToString());
    //    }
    //}

    void Start()
    {
        playerMovement= GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        Reset();
        //projectile = GetComponent<Projectile>();
    }


    //Chamar essa função quando o player aperta a carta desejada e olhar no inspetor para qual tipo de upgrade ele quer
    public void Upgrade(TipoUpgrade tipo)
    {
        int index = ((int)tipo);

        if (maxLevels[index] == currentLevels[index])
        {
            Debug.Log("Trying to upgrade further than max level in " + tipo.ToString());
            return;
        }

        currentLevels[index]++;
        Debug.Log(tipo.ToString() + " upgraded to " + currentLevels[index] + "!");

        switch(tipo)
        {
            case TipoUpgrade.Dash:
                playerMovement.atualizarDash(currentLevels[index]); break;
            case TipoUpgrade.Speed:
                playerMovement.atualizarMoveSpeed(currentLevels[index]); break;
            case TipoUpgrade.Health:
                vida.atualizarVida(currentLevels[index]); break;
            case TipoUpgrade.Damage:
                break;
        }

        //switch (tipo)
        //{
        //    case "Dash":
        //        if (dashLevel < 3)
        //        {
        //            dashLevel++;
        //            playerMovement.atualizarDash(dashLevel);
        //        }
        //        else Debug.Log("Dash passou do nivel 3: " + dashLevel);
        //            break;

        //    case "Speed":
        //        if (speedLevel < 3)
        //        {
        //            speedLevel++;
        //            playerMovement.atualizarMoveSpeed(speedLevel);
        //        }
        //        else Debug.Log("Speed passou do nivel 3: " + speedLevel);

        //        break;

        //    case "MaxHealth":
        //        if (healthLevel < 3)
        //        {
        //            healthLevel++;
        //            vida.atualizarVida(healthLevel);
        //            Debug.Log("Upgrade MaxHealth funcionou : " + healthLevel);
        //        }
        //        break;

        //    case "Damage":
        //        if (damageLevel < 3)
        //        {
        //            damageLevel++;
        //            playerMovement.atualizarMoveSpeed(damageLevel);
        //        }
        //        break;

        //    case "ProjectileCooldown":
        //        if (projectileCooldownLevel < 3)
        //        {
        //            projectileCooldownLevel++;
        //            playerMovement.atualizarMoveSpeed(projectileCooldownLevel);
        //        }
        //        break;
        //}
    }

    public void Reset()
    {
        //for (int i = 0; i < currentLevels.Length; i++)
        //{
        //    currentLevels[i] = 0;
        //}
        currentLevels = new int[5] { 0, 0, 0, 0, 0 };

        //PlayerMovement.cs
        playerMovement.atualizarDash(0);
        //dashLevel = 0;
        playerMovement.atualizarMoveSpeed(0);
        //speedLevel = 0;

        //Vida.cs
        playerMovement.atualizarMoveSpeed(0);
        //healthLevel = 0;

        //Projectile.cs
    }


    public bool IsAtMaxLevel(TipoUpgrade tipo)
    {
        int index = (int)tipo;

        if (currentLevels[index] == currentLevels[index])
        {
            return true;
        }
        return false;
    }

}

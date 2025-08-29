using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class MeleeDamage : MonoBehaviour
{
    public Inimigos Inimigos;
    Vida vidaPlayer;

    public float damage;
    float curTime = 0;
    float nextDamage = 1;

    public TipoInimigo tipoInimigo;


    public enum TipoInimigo
    {
        MeleeDamage,
        TankDamage,
    };

    void Start()
    {
        vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        QuantoDano();
    }

    void OnTriggerStay2D()
    {
        if (curTime <= 0)
        {
            vidaPlayer.TakeDamage(damage); // dano no player

            curTime = nextDamage; // timer para o próximo dano
        }
        else
        {

            curTime -= Time.deltaTime; // decrementa o timer
        }
    }


    public void QuantoDano()
    {
        switch (tipoInimigo)
        {
            case TipoInimigo.MeleeDamage:
                damage = Inimigos.meleeDano;
                break;
            case TipoInimigo.TankDamage:
                damage = Inimigos.tankDano;
                break;
        }

    }
}

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
    private bool damagingPlayer;

    public TipoInimigo tipoInimigo;


    public enum TipoInimigo
    {
        MeleeDamage,
        TankDamage,
    };

    public void FixedUpdate()
    {
        
    }

    void Start()
    {
        vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        QuantoDano();
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

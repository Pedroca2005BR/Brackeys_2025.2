using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class MeleeDamage : MonoBehaviour
{
    public Inimigos Inimigos;
    Vida vidaPlayer;

    public float damage;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vidaPlayer.TakeDamage(damage);
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

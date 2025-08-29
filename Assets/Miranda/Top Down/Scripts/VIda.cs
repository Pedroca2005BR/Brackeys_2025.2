using UnityEngine;

public class Vida : MonoBehaviour
{
    Rigidbody2D rb;
    public Inimigos Inimigos;
    public PlayerStats PlayerStats;
    public Tipo tipo;
    private bool hasShield;

    [SerializeField] float health, shieldHealth;
    public enum Tipo 
    { 
        Melee,
        Tank,
        Ranged,
        Player
    };
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        atualizaVida();
        Health();
    }
    public void TakeDamage(float damage)
    {
        if (!hasShield)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                //Mandar XP
            }
        }
        else
        {
            shieldHealth -= damage;
            hasShield = false;

        }
    }

    public void Health()
    {
        switch (tipo) 
        {
            case Tipo.Melee:
                health = Inimigos.meleeMaxHealth;
                break;
            case Tipo.Tank:
                health = Inimigos.tankMaxHealth;
                break;
            case Tipo.Ranged:
                health = Inimigos.rangedMaxHealth;
                break;
            case Tipo.Player:
                health = PlayerStats.maxHealth[0];
                break;

        }
            
    }
    public void atualizaVida()
    {
        
    }
}

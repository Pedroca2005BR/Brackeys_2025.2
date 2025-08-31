using UnityEngine;

public class Vida : MonoBehaviour
{
    Rigidbody2D rb;
    public Inimigos Inimigos;
    public PlayerStats PlayerStats;
    public Tipo tipo;
    private bool hasShield, isplayer = false;

    [SerializeField] float health, shieldHealth;
    public enum Tipo 
    { 
        Melee = 1,
        Tank = 3,
        Ranged = 4,
        Player = 0
    };
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Health();
    }
    public
        void TakeDamage(float damage)
    {

        if(isplayer) SoundManager.PlaySound(SoundType.SOFRERDANO);

        if (!hasShield) // Se não tiver escudo entra aqui
        {
            health -= damage;
            if (health <= 0)
            {
                if (isplayer)
                {
                    //Game Over
                    //Função pra acabar o jogo
                    Debug.Log("Game Over");

                }
                else
                {
                    //Mandar XP
                    LevelUpManager.instance.IncreaseExp((int)tipo);
                    Destroy(gameObject);
                    
                }

            }
        }
        else
        {
            shieldHealth -= damage;

            if (shieldHealth <= 0) hasShield = false;

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
                shieldHealth = Inimigos.shieldMaxHealth;
                hasShield = true;
                break;

            case Tipo.Ranged:
                health = Inimigos.rangedMaxHealth;
                break;

            case Tipo.Player:
                isplayer = true;
                atualizarVida(0);
                health = PlayerStats.maxHealth[0];
                break;

        }
            
    }
    public void atualizarVida(int nivel)
    {
        health = PlayerStats.maxHealth[nivel];
    }
}

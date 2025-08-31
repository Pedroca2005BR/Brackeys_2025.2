using UnityEngine;

public class Explosao : MonoBehaviour
{
    public Inimigos inimigos; // Referência ao script Inimigos para acessar o dano
    private GameObject area; // Referência ao script AreaExplosao para destruir a área após a explosão

    public float splashRange; // Dano da explosão na área
    public float rangeDamage; // Dano da explosão na área

    public Vector2 local; // Posição do alvo da explosão
    public GameObject areaExplosao; // Prefab da área de explosão

    Vida vida;

    private void Start()
    {
        vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        rangeDamage = inimigos.rangedDano; // Definir o dano da explosão com base no inimigo
        splashRange = inimigos.splashRange; // Definir o alcance da explosão com base no inimigo
    }

    public void LocalExplosão(Vector2 target)
    {
        Instantiate(areaExplosao, target, Quaternion.identity); // Instanciar a explosão na posição do alvo
        local = target; // Atualizar a posição do alvo
        area = GameObject.FindGameObjectWithTag("explosion");
    }
        

    public void Explodir()
    {
        SoundManager.PlaySound(SoundType.BOOM); // Som de explosão
        Dano(); // Dar dano na area se o player estiver na area
        Destroy(area); // Destruir o objeto de explosão
    }

    public void Dano()
    {
        var hitColliders = Physics2D.OverlapCircleAll(local, splashRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                vida.TakeDamage(rangeDamage);
            }
        }

    }
}

using UnityEngine;

public class Explosão : MonoBehaviour
{
    public Inimigos inimigos; // Referência ao script Inimigos para acessar o dano

    public float splashRange; // Dano da explosão na área
    public float rangeDamage; // Dano da explosão na área

    Transform Transform;
    public GameObject areaExplosao; // Prefab da área de explosão

    Vida vidaPlayer;

    private void Start()
    {
        vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
        rangeDamage = inimigos.rangedDano; // Definir o dano da explosão com base no inimigo
        splashRange = inimigos.splashRange; // Definir o alcance da explosão com base no inimigo
    }

    public void LocalExplosão(Vector2 target)
    {
        Instantiate(areaExplosao, target, Quaternion.identity); // Instanciar a explosão na posição do alvo
    }
        

    public void Explodir()
    {
        Debug.Log("2");
        SoundManager.PlaySound(SoundType.BOOM); // Som de explosão
        Debug.Log("3");
        Dano(); // Dar dano na area se o player estiver na area
        Debug.Log("4");
        Destroy(areaExplosao); // Destruir objeto explosão
        Debug.Log("5");
    }

    public void Dano()
    {
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                vidaPlayer.TakeDamage(rangeDamage);
            }
        }

    }
}

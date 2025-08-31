using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class Arremesaveis : MonoBehaviour
{
    public PlayerStats PlayerStats;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public int nivel = 0;
    [SerializeField] private float RangeDamage; // Dano do ataque a distancia

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atualizar();
        StartCoroutine(SelfDestruct());
    }
    

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
            Vida inimigo = collider.GetComponent<Vida>();
            if (collider.CompareTag("Inimigo"))
            {
                Destroy(gameObject);// destroi a flecha junto com o inimigo
                inimigo.TakeDamage(RangeDamage);// Aplica dano ao inimigo 
            }
    }


    private void atualizar()
    {
        RangeDamage = PlayerStats.projectileDamage[nivel];  
    }

}

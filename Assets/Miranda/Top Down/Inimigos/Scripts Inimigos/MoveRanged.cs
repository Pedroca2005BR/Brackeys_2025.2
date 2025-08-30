using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRanged : MonoBehaviour
{
    [SerializeField]public float shootingRange; // distancia que o inimigo vai começar a atacar
    [SerializeField]public float moveSpeed; // velocidade de movimento do inimigo
    Rigidbody2D rb;
    public Vector2 moveDirection;

    public Inimigos Inimigos;
    public ShooterFinal ShooterFinal;
    Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveSpeed = Inimigos.rangedMoveSpeed; //pega os valores do scriptable object
        shootingRange = Inimigos.rangedAttackRange;
    }

    private void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance <= shootingRange)
        {
            ShooterFinal.Atirar();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    }

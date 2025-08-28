using UnityEngine;

public class MoveMelee : MonoBehaviour
{

    public Inimigos Inimigos;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    [SerializeField] public bool isTank = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (!isTank)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * Inimigos.meleeMoveSpeed; // Velocidade Melee
        }
        else
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * Inimigos.tankMoveSpeed; // VElocidade Tank
        }
    }
}

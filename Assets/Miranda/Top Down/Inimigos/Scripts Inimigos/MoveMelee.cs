using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MoveMelee : MonoBehaviour
{

    public Inimigos Inimigos;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private Animator _animator;
    [SerializeField] public bool isTank = false;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    void Update()
    {
        moveDirection.Set(InputManager.Movement.x, InputManager.Movement.y);
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        _animator.SetFloat(_horizontal, moveDirection.x); //animação do jogador ao andar para direita e para esquerda
        _animator.SetFloat(_vertical, moveDirection.y); //animação do jogador ao andar para cima e para baixo
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

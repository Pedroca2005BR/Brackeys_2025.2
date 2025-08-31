using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MoveMelee : MonoBehaviour
{

    public Inimigos Inimigos;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private Animator _animator;
    [SerializeField] public bool isTank = false;

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

        
        if (moveDirection.x < 0) gameObject.transform.localScale = new Vector3(-3, 3, 1);
        else gameObject.transform.localScale = new Vector3(3, 3, 1);
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


    //// Time shit
    //private void OnGameStateChanged(GameState state)
    //{
    //    bool isEnabledVariable = state == GameState.Gameplay;

    //    if (!isEnabledVariable)
    //    {
    //        rb.linearVelocity = Vector2.zero;
    //        //RigidbodySleepMode2D.
    //    }
    //    enabled = isEnabledVariable;

    //}

    //private void OnEnable()
    //{
    //    GameStateManager.instance.OnGameStateChanged += OnGameStateChanged;
    //}

    //private void OnDisable()
    //{
    //    GameStateManager.instance.OnGameStateChanged -= OnGameStateChanged;
    //}
}

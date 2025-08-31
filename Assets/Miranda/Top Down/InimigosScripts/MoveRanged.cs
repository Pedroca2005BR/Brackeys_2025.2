using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRanged : MonoBehaviour
{
    [SerializeField]public float shootingRange; // distancia que o inimigo vai começar a atacar
    [SerializeField]public float moveSpeed; // velocidade de movimento do inimigo
    
    private Rigidbody2D rb;

    public Vector2 moveDirection;

    float inputX;

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
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;

        if (moveDirection.x < 0)gameObject.transform.localScale = new Vector3(-3,3,1);
        else gameObject.transform.localScale = new Vector3(3, 3, 1);

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


    //// Time shit
    //private void OnGameStateChanged(GameState state)
    //{
    //    bool isEnabledVariable = state == GameState.Gameplay;

    //    if (!isEnabledVariable)
    //    {

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

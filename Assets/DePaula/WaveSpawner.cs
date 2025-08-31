using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [Header("Position Values")]
    [SerializeField] private Transform player;
    [SerializeField] private float noSpawnRadius = 10f;

    [Header("Enemy Info")]
    [SerializeField] private EnemySpawnInfo[] enemies;
    //[SerializeField] private Transform[] positions;


    [Header("Wave Power")]
    [SerializeField] private int waveBudget = 20;
    [SerializeField] private float waveBudgetMultiplier = 1.5f;
    [SerializeField] private float spawnCooldown = 0.5f;
    [SerializeField][Range(0.01f, 1f)] private float cooldownMultipler = 1f;

    [Header("Victory Condition")]
    [SerializeField] private int finalWave = 10;
    int wavesEnded = 0;
    int currentWave = 0;



    #region Singleton

    public static WaveSpawner instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    #endregion


    private void Start()
    {
        currentWave = 0;
        //waveBudget =
    }

    public void SpawnNextWave()
    {
        currentWave++;
        
        SpawnWave(waveBudget);

        // Ao terminar o spawn da wave, aumenta o budget usando o multiplier
        float aux = waveBudget * waveBudgetMultiplier;
        waveBudget = (int)aux;
    }

    private bool TrySpawnEnemy(int i)
    {
        // Se o inimigo nao pode ser spawnado ainda, retorna falso
        if (enemies[i].blockUntilWave > currentWave)
        {
            return false;
        }

        if (enemies[i].chanceToSpawn < UnityEngine.Random.value)
        {
            return false;
        }


        //int rand = UnityEngine.Random.Range(0, positions.Length);


        //Instantiate(enemies[i].enemy, positions[rand].position, Quaternion.identity, this.transform);
        Instantiate(enemies[i].enemy, GetRandomSpawnPosition(), Quaternion.identity, this.transform);   // Spawna ao redor do player

        return true;
    }

    public void SpawnWave(int budget)
    {
        IEnumerator coroutine = SpawnWaveCoroutine(budget, currentWave);
        StartCoroutine(coroutine);
    }

    // O coefficiente de dificuldade da wave se refere ao expoente usado no calculo de cooldown entre spawn de um inimigo e outro
    private IEnumerator SpawnWaveCoroutine(int budget, int waveDifficultyCoefficient)
    {
        int rand;
        float time = (float)(spawnCooldown * (Math.Pow(cooldownMultipler, waveDifficultyCoefficient)));
        do
        {
            rand = UnityEngine.Random.Range(0, enemies.Length);
            if (TrySpawnEnemy(rand))
            {
                budget -= enemies[rand].cost;
            }           

            yield return new WaitForSeconds(time);

        } while (budget > 0);

        wavesEnded++;
    }

    private Vector2 GetRandomSpawnPosition()
    {

        float angle;

        float spawnX;
        float spawnY;
        Collider2D col;

        Vector2 pos;

        //if (Physics2D.BoxCast(pos, Vector2.one, 0f, Vector2.zero))
        //{
        //    pos *= -1;
        //}

        do
        {
            angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);
            spawnX = player.position.x + Mathf.Cos(angle) * noSpawnRadius;
            spawnY = player.position.y + Mathf.Sin(angle) * noSpawnRadius;
            pos = new Vector2(spawnX, spawnY);

            col = Physics2D.OverlapCircle(pos, 0.5f);

        } while (col != null && col.CompareTag("Border"));

        return pos;
    }

    public void CheckWinCondition()
    {
        if (finalWave == wavesEnded)
        {
            IEnumerator rotina = HasEnemiesOnScreen();
            StartCoroutine(rotina);
        }
    }

    IEnumerator HasEnemiesOnScreen()
    {
        yield return new WaitForSeconds(1f);
        if (transform.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);   // Scene final : vitoria
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.position, noSpawnRadius);
    }
}

[System.Serializable]
public class EnemySpawnInfo
{
    public GameObject enemy;
    public int cost = 1;
    public int blockUntilWave = 0;
    public float chanceToSpawn = 1f;
}

using System;
using System.Collections;
using UnityEngine;

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

    int waveNumber = 0;

    public void SpawnNextWave()
    {
        waveNumber++;
        
        SpawnWave(waveBudget);

        // Ao terminar o spawn da wave, aumenta o budget usando o multiplier
        float aux = waveBudget * waveBudgetMultiplier;
        waveBudget = (int)aux;
    }

    private bool TrySpawnEnemy(int i)
    {
        // Se o inimigo nao pode ser spawnado ainda, retorna falso
        if (enemies[i].blockUntilWave > waveNumber)
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
        IEnumerator coroutine = SpawnWaveCoroutine(budget, waveNumber);
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
    }

    private Vector2 GetRandomSpawnPosition()
    {

        float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f);

        float spawnX = player.position.x + Mathf.Cos(angle) * noSpawnRadius;
        float spawnY = player.position.y + Mathf.Sin(angle) * noSpawnRadius;

        return new Vector2(spawnX, spawnY);
    }
}

[System.Serializable]
public class EnemySpawnInfo
{
    public GameObject enemy;
    public int cost = 1;
    public int blockUntilWave = 0;
}

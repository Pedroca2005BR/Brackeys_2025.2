using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnInfo[] enemies;
    [SerializeField] private Transform[] positions;

    [Header("Wave Power")]
    [SerializeField] private int waveBudget = 20;
    [SerializeField] private float waveDifficultyMultiplier = 1.5f;

    int waveNumber = 0;

    public void SpawnNextWave()
    {
        waveNumber++;
        int currentBudget = waveBudget;

        int rand;
        do
        {
            rand = Random.Range(0, enemies.Length);
            if(TrySpawnEnemy(rand))
            {
                currentBudget -= enemies[rand].cost;
            }


        } while (currentBudget > 0);

        // Ao terminar o spawn da wave, aumenta o budget usando o multiplier
        float aux = waveBudget * waveDifficultyMultiplier;
        waveBudget = (int)aux;
    }

    private bool TrySpawnEnemy(int i)
    {
        // Se o inimigo nao pode ser spawnado ainda, retorna falso
        if (enemies[i].blockUntilWave > waveNumber)
        {
            return false;
        }



        int rand = Random.Range(0, positions.Length);

        Instantiate(enemies[i].enemy, positions[rand].position, Quaternion.identity, this.transform);

        return true;
    }
}

[System.Serializable]
public class EnemySpawnInfo
{
    public GameObject enemy;
    public int cost = 1;
    public int blockUntilWave = 0;
}

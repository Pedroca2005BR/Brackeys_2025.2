using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    //[SerializeField] playerMovement player;

    [Header("Level System")]
    [SerializeField] int expToLevelUp = 20;
    [SerializeField][Range(1f, 2f)] float expRequirementMultiplier = 1.0f;
    [SerializeField] int maxLevel = 5;
    public int currentLevel = 0;
    public int currentProgress = 0;

    [Header("Appendages")]
    [SerializeField] GameObject cardDisplays;
    [SerializeField] CardGenerator cardGenerator;

    public void IncreaseExp(int amount)
    {
        currentProgress += amount;

        if (currentProgress >= expToLevelUp && currentLevel < maxLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        currentProgress -= expToLevelUp;
        expToLevelUp *= (int)(expRequirementMultiplier);

        CallCardSystem();
    }

    private void CallCardSystem()
    {
        Time.timeScale = 0f;
        //PauseController.instance.ToggleGameState();
        cardDisplays.SetActive(true);
        cardGenerator.DisplayCards();
    }

    public void InflictCardEffect(Card card)
    {
        // Restaurando ao normal
        Time.timeScale = 1f;
        //PauseController.instance.ToggleGameState();
        cardDisplays.SetActive(false);

        // Fazendo a mudança
        switch(card.tipo)
        {
            case Card.TipoCarta.Normal:
                Upgrades.instance.Upgrade(card.tipoUpgrade); break;
            case Card.TipoCarta.Cookie:
                WaveSpawner.instance.SpawnWave(card.waveBudget); break;
            case Card.TipoCarta.Special:
                // TO DO
                break;
        }
    }

    #region Singleton

    public static LevelUpManager instance;

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


}

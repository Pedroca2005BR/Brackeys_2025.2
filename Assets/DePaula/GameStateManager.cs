using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Singleton

    public static GameStateManager instance;

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

    public GameState currentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newState);

    public event GameStateChangeHandler OnGameStateChanged;

    public void SetGameState(GameState newState)
    {
        if (currentGameState != newState)
        {
            currentGameState = newState;
            OnGameStateChanged?.Invoke(newState);
        }
    }
}

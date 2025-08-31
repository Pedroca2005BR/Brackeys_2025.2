using UnityEngine;

public class PauseController : MonoBehaviour
{
    #region Singleton

    public static PauseController instance;

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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleGameState();
        }
    }

    public void ToggleGameState()
    {
        GameState state = GameStateManager.instance.currentGameState;
        GameState newGameState = state == GameState.Gameplay ? GameState.Paused : GameState.Gameplay;

        GameStateManager.instance.SetGameState(newGameState);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public Controls Controls;
    public enum State 
    {
        PLAY,
        WIN,
        LOSE,
    }

    public State CurrentState { get; private set; }

    public void LoseLevel()
    {
        //if (CurrentState != State.PLAY) return;
        if (CurrentState == State.LOSE)
        //CurrentState = State.LOSE;
        Controls.enabled = false;
        Debug.Log("Game Over!");
        ReloadLevel();
    }

    public void FinishLevel()
    {
        //if (CurrentState != State.PLAY) return;
        if (CurrentState == State.WIN)
        //CurrentState = State.WIN;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You win!");
        ReloadLevel();
    }
    public int LevelIndex 
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set 
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

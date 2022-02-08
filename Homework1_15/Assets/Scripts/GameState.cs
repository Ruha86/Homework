using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    AudioListener audioListener;

    public Controls Controls;

    public GameObject UI;
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public Particle Fireworks;

    public enum State 
    {
        PLAY,
        WIN,
        LOSE,
    }
    private void Awake()
    {
        UI.SetActive(true);
        LoseScreen.SetActive(false);
        WinScreen.SetActive(false);
    }

    public State CurrentState { get; private set; }

    public void OnPlayerPlay() 
    {
        CurrentState = State.PLAY;
        Controls.enabled = true;
        SoundPause(true);
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.PLAY) return;

        CurrentState = State.LOSE;
        Controls.enabled = false;
        SoundPause(true);
        UI.SetActive(false);
        LoseScreen.SetActive(true);
        Debug.Log("Game Over! Sorry, you lose!");
        // ReloadLevel();
    }

    public void PlayerIsOnFinishPlatform()
    {
        if (CurrentState != State.PLAY) return;

        CurrentState = State.WIN;
        Controls.enabled = false;
        SoundPause(true);
        UI.SetActive(false);
        WinScreen.SetActive(true);
        LevelIndex++;
        Debug.Log("You win!");
        // ReloadLevel();
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

    public void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundPause(false);
    }
    private void SoundPause(bool pause)
    {
        AudioListener.pause = pause;
    }
    
}

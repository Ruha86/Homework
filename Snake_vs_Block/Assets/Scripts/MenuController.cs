using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame(string SceneName)
    {
        SceneManager.LoadScene("Level 1");
    }

    public void SwitchLevel(string SceneName) 
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

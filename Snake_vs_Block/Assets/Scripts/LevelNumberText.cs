using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumberText : MonoBehaviour
{
    public Text LevelNumber;
    public GameState GameState;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        LevelNumber.text = scene.name;
    }

}

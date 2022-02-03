using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumberText : MonoBehaviour
{
    public Text text;
    public GameState GameState;
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        text.text = scene.name;
    }

}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumberText : MonoBehaviour
{
    public Text LevelNumber;
    public Text FoodCounter;

    public GameState GameState;

    int counter;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        LevelNumber.text = scene.name;

        counter = GetComponent<Player>().foodCounter;
    }

    private void Update()
    {

        FoodCounter.text = counter.ToString();

        Debug.Log(counter);
    }
}

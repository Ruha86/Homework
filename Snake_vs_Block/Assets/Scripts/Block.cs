using Random = System.Random;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMesh text;

    public int Value;
    private float ColorChange;

    Random random = new Random();

    private int minBlockValue = 1;
    private int maxBlockValue = 31;

    void Start()
    {
        Value = random.Next(minBlockValue, maxBlockValue);

        text.text = Value.ToString();
        // ColorChange = Value / 10;
    }

}

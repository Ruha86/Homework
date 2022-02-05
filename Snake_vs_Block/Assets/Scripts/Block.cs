using Random = System.Random;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMesh BlockValue;
    public int Value;

    public Material BlockMat;

    Random random = new Random();

    private int minBlockValue = 1;
    private int maxBlockValue = 31;

    
    void Start()
    {
        Value = random.Next(minBlockValue, maxBlockValue);
        BlockValue.text = Value.ToString();

        this.BlockMat.SetFloat("_ColorValue", Value / 20f);

    }
    
}

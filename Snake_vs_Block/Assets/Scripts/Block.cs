using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMesh Text;
    public int Value;
    private float ColorChange;



    void Start()
    {
        Text.text = Value.ToString();
        // ColorChange = Value / 10;
    }

}

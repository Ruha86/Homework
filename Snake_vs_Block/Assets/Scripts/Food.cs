using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public int Value;
    public TextMesh text;

    

    private void Start()
    {
        text.text = Value.ToString();
    }
}

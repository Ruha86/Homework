using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public Food Food;
    public Block Block;

    public GameObject Food_prefab;
    public GameObject Block_prefab;

    private int foodMinValue = 1;
    private int foodMaxValue = 10;
    private int blockMinValue = 1;
    private int blockMaxValue = 100;

    private int FoodValue; // food value
    private int BlockValue; // block value

    Random rnd = new Random();

    void Start()
    {
        
    }

    public void GetRandomFoodValue() 
    {
        int rndFoodValue = rnd.Next(foodMinValue,foodMaxValue + 1);
    }

    public void GetRandomBlockValue() 
    {
        int rndBlockValue = rnd.Next(blockMinValue, blockMaxValue);
    }
}

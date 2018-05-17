using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public int score = 0;
    public static Manager Instance { get; private set; }
    public ParticleSystem smoke;
    public static int WATER_LEVEL = 10000;

    public enum flowerType
    {
        Tomate,
        Mais,
        Radis,
        Carotte,
        Aubergine,
        Potiron
    }

    public int time, sun;
    public Dictionary<int, flowerType> flower = new Dictionary<int, flowerType>();
    public Dictionary<flowerType, int> tailleFlower = new Dictionary<flowerType, int>();
    public Dictionary<flowerType, int> tailleMax = new Dictionary<flowerType, int>();
    public Dictionary<int, int> nbFruit = new Dictionary<int, int>();
    public Dictionary<int, bool> haveFruit = new Dictionary<int, bool>();
    public Dictionary<int, bool> isSet = new Dictionary<int, bool>();
    public Dictionary<int, float> length = new Dictionary<int, float>();
    public Dictionary<int, int> water = new Dictionary<int, int>();

    private Dictionary<flowerType, float> flowerSpeed = new Dictionary<flowerType, float>();
    private Dictionary<flowerType, float> flowerWater = new Dictionary<flowerType, float>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        config();
    }

    private void config()
    {
        //Set a type of plant for each garden bed
        flower.Add(0, flowerType.Potiron);
        flower.Add(1, flowerType.Mais);
        flower.Add(2, flowerType.Radis);
        flower.Add(3, flowerType.Carotte);
        flower.Add(4, flowerType.Aubergine);
        flower.Add(5, flowerType.Potiron);
        flower.Add(6, flowerType.Mais);
        flower.Add(7, flowerType.Tomate);

        //Set the size of each plant
        tailleFlower.Add(flowerType.Tomate, 2);
        tailleFlower.Add(flowerType.Mais, 2);
        tailleFlower.Add(flowerType.Radis, 0);
        tailleFlower.Add(flowerType.Aubergine, 2);
        tailleFlower.Add(flowerType.Potiron, 2);
        tailleFlower.Add(flowerType.Carotte, 0);

        //Set the speed of grow for each plant
        tailleMax.Add(flowerType.Tomate, 3);
        tailleMax.Add(flowerType.Mais, 3);
        tailleMax.Add(flowerType.Radis, 1);
        tailleMax.Add(flowerType.Aubergine, 3);
        tailleMax.Add(flowerType.Potiron, 4);
        tailleMax.Add(flowerType.Carotte, 1);

        //Set the speed of grow for each plant
        flowerSpeed.Add(flowerType.Tomate, 0.000002f);
        flowerSpeed.Add(flowerType.Mais, 0.00001f);
        flowerSpeed.Add(flowerType.Radis, 0.000005f);
        flowerSpeed.Add(flowerType.Aubergine, 0.000005f);
        flowerSpeed.Add(flowerType.Potiron, 0.00003f);
        flowerSpeed.Add(flowerType.Carotte, 0.000003f);

        //Set the importance of water for each plant
        flowerWater.Add(flowerType.Tomate, 0.5f);
        flowerWater.Add(flowerType.Mais, 2f);
        flowerWater.Add(flowerType.Radis, 1f);
        flowerWater.Add(flowerType.Aubergine, 1f);
        flowerWater.Add(flowerType.Potiron, 10f);
        flowerWater.Add(flowerType.Carotte, 1f);
    }

    // Use this for initialization
    void Start()
    {
        time = 0;
        sun = 1;
        for (int i = 0; i < 8; i++)
        {
            length.Add(i, 0);
            water.Add(i, 0);
            nbFruit.Add(i, 0);
            haveFruit.Add(i, false);
            isSet.Add(i, false);
        }
    }

    public void decrementWater(int i)
    {
        if (water[i] > 0)
        {
            water[i] -= 2;
        }
    }

    public void incrementWater(int i)
    {
        if (water[i] < WATER_LEVEL)
        {
            water[i] += 50;
        }
    }

    public bool IsFruitReady(int num)
    {
        return length[num] >= tailleMax[flower[num]];
    }

    // Update is called once per frame
    void Update()
    {
        time += 1;
        for (int i = 0; i < 8; i++)
        {
            decrementWater(i);
            if (length[i] <= tailleMax[flower[i]] && isSet[i])
            {
                length[i] += flowerSpeed[flower[i]] * ((water[i]/10) / flowerWater[flower[i]]);
            }
        }
    }
}

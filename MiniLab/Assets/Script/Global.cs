using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
        [Header("текстовые объекты")]
        [Space]
    public Text NumOfBactT; public Text NumOfPlantT, CurentPlant, CurentPray, CurentPredator;
        [Header("общие штуки")]
        [Space]
    public int NumOfBact; public int NumOfPlant, MutationChance, ProcentOfSpeedMutation; public float Tick;
        [Header("переменые травоядного")]
        [Space]
    public float PreyHunger; public float FlowerEat, PreySpeed, PreyDead;
        [Header("переменые хищника")]
        [Space]
    public float PredatorHunger; public float PreyEat, PredatorSpeed, PredatorDead;
    public void Update()
    {
        NumOfBactT.text = NumOfBact.ToString();
        NumOfPlantT.text = NumOfPlant.ToString();
        CurentPlant.text = GameObject.FindGameObjectsWithTag("flower").Length.ToString();
        CurentPray.text = GameObject.FindGameObjectsWithTag("prey").Length.ToString();
        CurentPredator.text = GameObject.FindGameObjectsWithTag("predator").Length.ToString();
    }

    public void AddBact()
    {
        NumOfBact += 10;
    }

    public void RemoveBact()
    {
        NumOfBact -= 10;
        if (NumOfBact < 10)
        {
            NumOfBact = 10;
        }
    }

    public void AddPlant()
    {
        NumOfPlant += 10;
    }

    public void RemovePlant()
    {
        NumOfPlant -= 10;
        if (NumOfPlant < 10)
        {
            NumOfPlant = 10;
        }
    }
}

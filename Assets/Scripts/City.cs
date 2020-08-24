using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public int Cash { get; set; }
    public int Day { get; set; }
    public float PopulationCurrent{ get; set; }
    public float PopulationCeiling{ get; set; }
    public int JobsCurrent { get; set; }
    public int JobsCeiling { get; set; }
    public float Food { get; set; }

    public int[] buildingCounts = new int[4];
    private UIController uiController;

    void Start()
    {
        uiController = GetComponent<UIController>();
        Day = 1;
        Cash = 50;

        uiController.UpdateCityData();
        uiController.UpdateDayCount();
    }

    public void EndTurn()
    {
        Day++;
        CalculateCash();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();

        uiController.UpdateCityData();
        uiController.UpdateDayCount();
    }

    void CalculateJobs()
    {
        JobsCeiling = buildingCounts[3] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent);
    }

    void CalculateCash()
    {
        Cash += JobsCurrent * 2;
    }

    public void DepositCash(int cash)
    {
        Cash += cash;
    }

    void CalculateFood()
    {
        Food += buildingCounts[2] * 4f;
    }

    void CalculatePopulation()
    {
        PopulationCeiling = buildingCounts[1] * 5;

        if (Food >= PopulationCurrent && PopulationCurrent < PopulationCeiling)
        {
            Food -= PopulationCurrent * .25f;
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * .25f, PopulationCeiling);
        }
        else if (Food < PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent - Food) * .5f;
        }
    }
}

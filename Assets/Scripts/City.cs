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

    public int[] buildingCounts = new int[3];
    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GetComponent<UIController>();

        buildingCounts[0] = 4;
        buildingCounts[1] = 3;
        buildingCounts[2] = 2;

        Day = 1;
        Cash = 10000;
        Food = 6;
        JobsCeiling = 10;

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
        JobsCeiling = buildingCounts[2] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent);
    }

    void CalculateCash()
    {
        Cash += JobsCurrent * 2;
    }

    void CalculateFood()
    {
        Food += buildingCounts[1] * 4f;
    }

    void CalculatePopulation()
    {
        PopulationCeiling = buildingCounts[0] * 5;

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

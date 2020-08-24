using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text dayText;
    [SerializeField]
    private Text cityText;
    private City city;

    void Start()
    {
        city = GetComponent<City>();
    }

    public void UpdateCityData()
    {
        cityText.text = string.Format(
            "Cash: ${0} (+{1})\nPopulation: {2}/{3}\nFood: {4}\nJobs: {5}/{6}",
            city.Cash,
            city.JobsCurrent * 2,
            (int)city.PopulationCurrent,
            (int)city.PopulationCeiling,
            (int)city.Food,
            city.JobsCurrent,
            city.JobsCeiling
        );
    }

    public void UpdateDayCount()
    {
        dayText.text = string.Format("Day {0}", city.Day);
    }
}

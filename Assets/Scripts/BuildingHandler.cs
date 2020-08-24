using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    [SerializeField]
    private City city;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Board board;
    private Building selectedBuilding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            InteractWithBoard();
        }
    }

    void InteractWithBoard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 gridPosition = board.CalculateGridPosition(hit.point);

            if (!board.CheckForBuildingAtPosition(gridPosition))
            {
                if (city.Cash >= selectedBuilding.cost)
                {
                    city.Cash -= selectedBuilding.cost;
                    uiController.UpdateCityData();
                    city.buildingCounts[selectedBuilding.id]++;
                    board.AddBuilding(selectedBuilding, gridPosition);
                }
            }
        }
    }

    public void EnableBuilding(int building)
    {
        selectedBuilding = buildings[building];
        Debug.Log("Selected building" + selectedBuilding.buildingName);
    }
}

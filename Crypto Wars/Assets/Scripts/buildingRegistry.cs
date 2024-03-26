using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRegistry : MonoBehaviour
{
    // List of building types and grabs the card they produce from the card registry
    private List<Building> buildingList;
    private CardRegistry cList;

    // Initialized after cardRegistry since CreateBuilding relies on it
    void Start() 
    {
        // Create buildings that produces the cards
        CreateBuilding("Python Factory", "Python", 1, 3);
        CreateBuilding("Java Junction", "Java", 2, 5);
        CreateBuilding("C Workshop", "C", 1, 3);
    }

    // Creates the bulding types and adds them to buildingList
    void CreateBuilding(string name, string cardName, int numProduced, int turnsToProduce)
    {
        Building newBuild = new Building(name, numProduced, turnsToProduce);
        Card cardProduct = cList.GetCardByName(cardName);  
        newBuild.setCard(cardProduct);

        buildingList.Add(newBuild);
    }

    // Grabs building from the list by name
    public Building GetBuildingByName(string buildingName)
    {
        return buildingList.Find(build => build.getName() == buildingName);
    }
}

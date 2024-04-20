using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic; // For generic types

public class BuildingRegistryTest
{
    private GameObject gameObj;
    private BuildingRegistry buildingRegistry;

    [SetUp]
    public void SetUp()
    {
        // Create a new game object and add the BuildingRegistry component to it
        gameObj = new GameObject("BuildingManager");
        buildingRegistry = gameObj.AddComponent<BuildingRegistry>();
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup after each test
        GameObject.DestroyImmediate(gameObj);
    }

    [Test]
    public void Start_InitializesBuildings_Correctly()
    {
        buildingRegistry.Start();  // Simulating Start method
        Assert.IsNotNull(buildingRegistry.GetBuildingByName("Python Factory"));
        Assert.IsNotNull(buildingRegistry.GetBuildingByName("Java Junction"));
        Assert.IsNotNull(buildingRegistry.GetBuildingByName("C Workshop"));
    }

    [Test]
    public void CreateBuilding_AddsBuildingToList_BuildingExists()
    {
        buildingRegistry.CreateBuilding("C# Lab", "C#", 2, 4);
        Building result = buildingRegistry.GetBuildingByName("C# Lab");
        Assert.IsNotNull(result);
        Assert.AreEqual("C#", result.getCard().getName());
        Assert.AreEqual(2, result.getNumProduced());
        Assert.AreEqual(4, result.getTurnsToProduce());
    }

    [Test]
    public void GetBuildingByName_ReturnsCorrectBuilding_WhenExists()
    {
        buildingRegistry.Start();  // Initialize buildings
        Building result = buildingRegistry.GetBuildingByName("Python Factory");
        Assert.IsNotNull(result);
        Assert.AreEqual("Python Factory", result.getName());
    }

    [Test]
    public void GetBuildingByName_ReturnsNull_WhenDoesNotExist()
    {
        buildingRegistry.Start();  // Initialize buildings
        Building result = buildingRegistry.GetBuildingByName("Nonexistent Building");
        Assert.IsNull(result);
    }

}



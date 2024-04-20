using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic; // For generic types

public class CardRegistryTest
{
    private GameObject gameObj;
    private CardRegistry cardRegistry;

    [SetUp]
    public void SetUp()
    {
        // Create a new game object and add the CardRegistry component to it
        gameObj = new GameObject("CardManager");
        cardRegistry = gameObj.AddComponent<CardRegistry>();
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup after each test
        GameObject.DestroyImmediate(gameObj);
    }

    [Test]
    public void Awake_CreatesCards_Correctly()
    {
        cardRegistry.Awake(); // Simulating Awake method

        Assert.IsNotNull(CardRegistry.GetCardByName("Python"));
        Assert.IsNotNull(CardRegistry.GetCardByName("Java"));
        Assert.IsNotNull(CardRegistry.GetCardByName("C"));
    }

    [Test]
    public void CreateCard_AddsCardToList_CardExists()
    {
        cardRegistry.CreateCard("Ruby", 100, 150, 10);
        Card result = CardRegistry.GetCardByName("Ruby");
        Assert.IsNotNull(result);
        Assert.AreEqual("Ruby", result.getName());
        Assert.AreEqual(100, result.getOffense());
        Assert.AreEqual(150, result.getDefense());
        Assert.AreEqual(10, result.getStaminaCost());
    }

    [Test]
    public void GetCardByName_ReturnsCorrectCard_WhenExists()
    {
        cardRegistry.Awake();  // Initialize cards
        Card result = CardRegistry.GetCardByName("Python");
        Assert.IsNotNull(result);
        Assert.AreEqual("Python", result.getName());
    }

    [Test]
    public void GetCardByName_ReturnsNull_WhenDoesNotExist()
    {
        cardRegistry.Awake();  // Initialize cards
        Card result = CardRegistry.GetCardByName("Nonexistent Card");
        Assert.IsNull(result);
    }
}

using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

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

        // Simulate the start up sequence that triggers Awake
        gameObj.SetActive(true);
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup after each test
        GameObject.DestroyImmediate(gameObj);
    }

    [Test]
    public void CardsAreInitializedCorrectly()
    {
        // Assuming Awake has been called due to the game object activation
        Assert.IsNotNull(CardRegistry.GetCardByName("Python"));
        Assert.IsNotNull(CardRegistry.GetCardByName("Java"));
        Assert.IsNotNull(CardRegistry.GetCardByName("C"));

        // Check attributes for one card to ensure they are set correctly
        Card pythonCard = CardRegistry.GetCardByName("Python");
        Assert.AreEqual(100, pythonCard.getOffense());
        Assert.AreEqual(150, pythonCard.getDefense());
        Assert.AreEqual(20, pythonCard.getStaminaCost());
    }

    [Test]
    public void GetCardByName_ReturnsCorrectCard_WhenExists()
    {
        // This checks retrieval method functionality
        Card result = CardRegistry.GetCardByName("Python");
        Assert.IsNotNull(result);
        Assert.AreEqual("Python", result.getName());
    }

    [Test]
    public void GetCardByName_ReturnsNull_WhenDoesNotExist()
    {
        // This tests the edge case of a non-existent card
        Card result = CardRegistry.GetCardByName("Nonexistent Card");
        Assert.IsNull(result);
    }
}

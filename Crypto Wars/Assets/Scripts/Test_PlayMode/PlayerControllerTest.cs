using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class PlayerControllerTest
{
    public GameObject go;
    public PlayerController testController;
    // public List<Player> testPlayerList;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("Controller");
        testController = go.AddComponent<PlayerController>();
        // testPlayerList = new List<Player>();
    }

    [Test]
    public void TestNextPlayer()
    {
        testController.NextPlayer();
        Assert.AreEqual(0, testController.GetCurrentPlayerIndex());
    }
    
    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(go);
    }
}
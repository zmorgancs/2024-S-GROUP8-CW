using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class InventoryManagerTest
{
    public GameObject go, canvas;
    public InventoryManager testManager;
    // new Battle testBattle;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("Manager");
        canvas = new GameObject("Canvas");
        testManager = go.AddComponent<InventoryManager>();
    }
    
    // I don't think we can test InventoryManager without refactoring
    // [Test]
    // public void TestSetText()
    // {
    //     Assert.AreEqual(testManager.Slots.Count, "pineapple");
    // }
    
    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(go);
    }
}
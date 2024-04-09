using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class GameManagerTest
{
    public GameObject go;
    public GameManager testManager;
    // new Battle testBattle;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("Manager");
        testManager = go.AddComponent<GameManager>();
    }

    // I don't think we can do tests involving Battle objects
    // without refactoring
    // [Test]
    // public void TestAddBattle()
    // {

    // }
    
    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(go);
    }
}
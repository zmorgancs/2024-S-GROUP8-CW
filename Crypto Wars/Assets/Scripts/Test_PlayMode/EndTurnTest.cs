using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class EndTurnTest
{
    public GameObject go;
    // public TextMeshProUGUI turnNumber; //for some reason I can't find TextMeshProUGUI
    int startNum;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("EndTurnButton");
        go.AddComponent<EndTurn>();
        // go.GetComponent<TextMeshProUGUI>();
        // turnOutput = go.GetComponent<TextMeshProUGUI>();
    }

    [Test]
    public void TestTurnNumberIncrement()
    {
        go.GetComponent<EndTurn>().endPlayerTurn();
        Assert.AreNotEqual(startNum, go.GetComponent<EndTurn>().turnNum);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(go);
    }
}
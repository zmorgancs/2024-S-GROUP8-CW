using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class EscapeMenuTest
{
    public GameObject go;
    public Canvas canvas;
    public EscapeMenu testMenu;
    // public TextMeshProUGUI turnOutput; for some reason I can't find TextMeshProUGUI
    bool gamePaused;
    Vector2 anchorPosition;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("EscapeButton");
        go.AddComponent<EscapeMenu>();
        testMenu = go.GetComponent<EscapeMenu>();
        canvas = go.AddComponent<Canvas>();
    }

    [Test]
    public void TestToggleMenu() // does not want to work, inactive objects gives issues
    {
        testMenu.ToggleMenu();
        Assert.AreEqual(Time.timeScale, 0);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(go);
    }
}

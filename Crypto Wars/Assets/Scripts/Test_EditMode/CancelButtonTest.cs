using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class CancelButtonTest
{
    public GameObject go;
    public CancelButton cancelButton;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("Cancel Button");
        go.AddComponent<CancelButton>();
        cancelButton = go.GetComponent<CancelButton>();
        go.transform.position = new Vector3(0, 0, 0);
    }

    [Test]
    public void TestOutOfFrame()
    {
        Vector3 expectedPosition = new Vector3(0,-375,0);
        cancelButton.outOfFrame();
        Assert.AreEqual(expectedPosition, go.transform.position);
    }
}
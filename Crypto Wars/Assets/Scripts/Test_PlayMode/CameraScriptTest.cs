using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CameraScriptTest
{
    public GameObject go;
    Vector3 startPos, previousPos;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("Camera");
        go.AddComponent<CameraScript>();
        Vector3 startPos = new Vector3(0, 0, 0);
    }

    [Test]
    public void TestCameraMovement()
    {
        Vector3 previousPos = startPos;
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(go);
    }
}
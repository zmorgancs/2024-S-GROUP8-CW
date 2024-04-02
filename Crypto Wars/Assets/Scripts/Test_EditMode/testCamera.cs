using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class CameraScriptTests
{
    private CameraScript cameraScript;
    private GameObject cameraGameObject;

    [SetUp]
    public void SetUp()
    {
        cameraGameObject = new GameObject();
        cameraScript = cameraGameObject.AddComponent<CameraScript>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(cameraGameObject);
    }

    /******************************************************
     *
     * TEST moveCamera up/down/left/right
     * 
     *******************************************************/

    [Test]
    public void testmoveCameraUp()
    {
        cameraScript.moveCamera(KeyCode.W, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None);
        Assert.AreEqual(new Vector3(0, 3 * cameraScript.cameraSpeed * Time.deltaTime, 0), cameraScript.transform.position);
    }

    [Test]
    public void testmoveCameraDown()
    {

        cameraScript.moveCamera(KeyCode.None, KeyCode.S, KeyCode.None, KeyCode.None, KeyCode.None);
        Assert.AreEqual(new Vector3(0, -3 * cameraScript.cameraSpeed * Time.deltaTime, 0), cameraGameObject.transform.position);
    }

    [Test]
    public void testmoveCameraLeft()
    {

        cameraScript.moveCamera(KeyCode.None, KeyCode.None, KeyCode.A, KeyCode.None, KeyCode.None);
        Assert.AreEqual(new Vector3(-3 * cameraScript.cameraSpeed * Time.deltaTime, 0, 0), cameraGameObject.transform.position);
    }

    [Test]
    public void testmoveCameraRight()
    {

        cameraScript.moveCamera(KeyCode.W, KeyCode.None, KeyCode.None, KeyCode.D, KeyCode.None);
        Assert.AreEqual(new Vector3(3 * cameraScript.cameraSpeed * Time.deltaTime, 0, 0), cameraGameObject.transform.position);
    }

    /******************************************************
    *
    * TEST resetCamera
    * 
    *******************************************************/

    [Test]
    public void testResetCamera()
    {
        cameraScript.moveCamera(KeyCode.W, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.Space);
        Assert.AreEqual(new Vector3(2.5f, 7.46f, -4f), cameraGameObject.transform.position);
    }

    /******************************************************
     *
     * TEST zoomCamera in/out
     * 
     *******************************************************/

    [Test]
    public void testZoomCameraIn()
    {
        float scrollDelta = 1.0f;
        cameraScript.zoomCamera(scrollDelta);
        Assert.AreEqual(new Vector3(2.5f, 5.5f + cameraScript.zoomAmount, -4f), cameraGameObject.transform.position);
    }

    [Test]
    public void testZoomCameraOut()
    {
        float scrollDelta = -1.0f;
        cameraScript.zoomCamera(scrollDelta);
        Assert.AreEqual(new Vector3(2.5f, 20f + cameraScript.zoomAmount, -4f), cameraGameObject.transform.position);
    }

    /******************************************************
     *
     * TEST setCameraPosition using a dummy tile
     * 
     *******************************************************/

    [Test]
    public void testSetCameraPosition()
    {
        // Arrange
        Tile tile = testTileDummy(new Vector2(10, 5)); // Create a mock tile
        Vector3 expectedPosition = new Vector3(0, cameraScript.defaultZ, 0); // Expected camera position after setting to tile position

        cameraScript.setCameraPosition(tile);

        Assert.AreEqual(expectedPosition, cameraGameObject.transform.position);
    }

    private Tile testTileDummy(Vector2 position)
    {
        // Create a GameObject and add Tile component to mock a tile
        GameObject tileGameObject = new GameObject("Tile");
        Tile tile = tileGameObject.AddComponent<Tile>();
        tile.BoardXPos = (int)position.x;
        tile.BoardYPos = (int)position.y;
        return tile;
    }
}


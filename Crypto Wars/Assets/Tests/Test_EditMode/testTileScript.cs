using NUnit.Framework;
using UnityEngine;

namespace Test
{
    public class TestTileScript
    {
        private GameObject tileGameObject;
        private Tile tileScript;
        private Material testMaterial;

        [SetUp]
        public void SetUp()
        {
            // Initialize Tile GameObject and Tile script before each test
            tileGameObject = new GameObject("Tile");
            tileScript = tileGameObject.AddComponent<Tile>();
            tileScript.BoardXPos = 5; // Sample position X
            tileScript.BoardYPos = 10; // Sample position Y

            // Set up a test material
            testMaterial = new Material(Shader.Find("Standard"));
        }
        
        [Test]
        public void Tile_SetPlayer_AssignsPlayerIndexCorrectly()
        {
            // Test to ensure the player index is set correctly
            int testPlayerIndex = 1;
            tileScript.SetPlayer(testPlayerIndex);
            Assert.AreEqual(testPlayerIndex, tileScript.GetPlayer());
        }

        [Test]
        public void Tile_SetMaterial_AssignsMaterialCorrectly()
        {
            // Test to ensure the material is set correctly
            tileScript.SetMaterial(testMaterial);
            Assert.AreEqual(testMaterial, tileScript.GetComponent<MeshRenderer>().material);
        }

        [Test]
        public void Tile_GetTilePosition_ReturnsCorrectPosition()
        {
            // Test to ensure the position is retrieved correctly
            Vector2 expectedPosition = new Vector2(5, 10);
            Assert.AreEqual(expectedPosition, tileScript.GetTilePosition());
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            Object.DestroyImmediate(tileGameObject);
        }
    }
}

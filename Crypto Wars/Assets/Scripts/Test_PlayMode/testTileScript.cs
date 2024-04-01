using NUnit.Framework;
using UnityEngine;
using UnityEditor;

namespace Test
{
    public class TestTileScript
    {
        public GameObject tileGameObject;
        public Tile tile;
        // public Tile.TileReference tileReference;
        public Material testMaterial;

        [SetUp]
        public void SetUp()
        {
            GameObject tileGameObject = new GameObject("Tile");
            tileGameObject.AddComponent<MeshRenderer>();
            tileGameObject.AddComponent<Tile>();

            // Initialize Tile GameObject and Tile script before each test
            tile = tileGameObject.GetComponent<Tile>();
            tile.rendererReference = tileGameObject.GetComponent<MeshRenderer>();
            // tile.tilePosition = new Vector2(5, 10);
            // tile.SetTilePosition(5, 10);

            // Set up a test material
            testMaterial = new Material(Shader.Find("Standard"));
        }
        
        [Test]
        public void Tile_SetPlayer_AssignsPlayerIndexCorrectly()
        {
            // Test to ensure the player index is set correctly
            int testPlayerIndex = 1;
            tile.SetPlayer(testPlayerIndex);
            Assert.AreEqual(testPlayerIndex, tile.GetPlayer());
        }

        [Test]
        public void Tile_SetMaterial_AssignsMaterialCorrectly()
        {
            // Test to ensure the material is set correctly
            tile.SetMaterial(testMaterial);
            string expectedName = testMaterial.name.Split(' ')[0];
            string actualName = tile.GetMaterial().name.Split(' ')[0];
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Tile_GetTilePosition_ReturnsCorrectPosition()
        {
            // Test to ensure the position is retrieved correctly
            Vector2 expectedPosition = new Vector2(5, 10);
            Assert.AreEqual(expectedPosition, tile.GetTilePosition());
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            Object.DestroyImmediate(tile);
        }
    }
}

using NUnit.Framework;
using UnityEngine;

namespace Test
{
    public class Testtile
    {
        private GameObject tileGameObject;
        public Tile tile;
        // public Tile.TileReference tileReference;
        public Material testMaterial;

        [SetUp]
        public void SetUp()
        {
            // Initialize Tile GameObject and Tile script before each test
            // tileGameObject = new GameObject("Tile");
            // tile = tileGameObject.AddComponent<Tile>();
            tile = new Tile();
            tile.SetTilePosition(5, 10);
            tileGameObject.AddComponent<MeshRenderer>();
            // tile.rendererReference = tileGameObject.GetComponent<MeshRenderer>();

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
            Assert.AreEqual(testMaterial, tile.GetMaterial());
            // Assert.AreEqual(testMaterial, tile.GetComponent<MeshRenderer>().material);
        }

        // [Test]
        // public void Tile_GetTilePosition_ReturnsCorrectPosition()
        // {
        //     // Test to ensure the position is retrieved correctly
        //     Vector2 expectedPosition = new Vector2(5, 10);
        //     Assert.AreEqual(expectedPosition, tile.GetTilePosition());
        // }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            Object.DestroyImmediate(tile);
        }
    }
}

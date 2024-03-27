using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//using Player;

public class testPlayerScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void testPlayerConstructor()
    {
        Material color = null;
        Player p1 = new Player("ogre", color);
        p1.PlayerFinishTurn();

        // Make sure class is created with correct parameters/variables
        Assert.AreEqual(p1.GetName(), "ogre");
        Assert.AreEqual(p1.CalculatePercentage(), 0);
        Assert.AreEqual(p1.IsPlayerTurnFinished(), true);
    }

    [Test]
    public void testPlayerVariables()
    {
        Material color = null;
        Player p1 = new Player("ogre", color);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rend = cube.GetComponent<Renderer>();
        Material playerColor = new Material(Shader.Find("Specular"));

        p1.SetColor(playerColor);
        // Make sure class is created with correct parameters/variables
        Assert.AreEqual(p1.GetColor(), playerColor);

        p1.SetName("Bob");
        Assert.AreEqual(p1.GetName(), "Bob");

        Tile.TileReference tile = new Tile.TileReference();
        p1.AddTiles(tile);
        Assert.AreEqual(p1.getTiles().Count, 1);
        Assert.AreEqual(p1.getTilesControlledCount(), 1);
    }
}
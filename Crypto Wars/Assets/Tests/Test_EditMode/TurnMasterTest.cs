using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMasterTest
{
    // Tests if players are all finished with their turn
    [Test]
    public void TestAllAreDone_True()
    {
        TurnMaster master = new TurnMaster();
        // One player list
        List<Player> players = new List<Player>
        {
            new Player("name", null)
        };

        players[0].PlayerFinishTurn();
        bool b = master.allAreDone(players.ToArray());
        Assert.IsTrue(b);
    }

    // Tests if players aren't finished with their turns
    [Test]
    public void TestAllAreDone_False()
    {
        TurnMaster master = new TurnMaster();
        // One player list
        List<Player> players = new List<Player>
        {
            new Player("name", null)
        };

        bool b = master.allAreDone(players.ToArray());
        Assert.IsFalse(b);
    }

    // Tests if a player can be moved into a new turn
    [Test]
    public void TestNewTurn()
    {
        TurnMaster master = new TurnMaster();
        // One player list
        List<Player> players = new List<Player>
        {
            new Player("name", null)
        };

        master.newTurn(players.ToArray());
        Assert.IsTrue(!players[0].IsPlayerTurnFinished());
    }

    // Tests if can get current turn
    [Test]
    public void TestGetCurrTurn()
    {
        TurnMaster master = new TurnMaster(); 
        Assert.AreEqual(master.getCurrTurn(), 0);
    }
}

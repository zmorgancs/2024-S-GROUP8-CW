using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMasterTest
{
    [Test]
    public void TestAllAreDone_True()
    {
        TurnMaster master = new TurnMaster();
        List<Player> players = new List<Player>
        {
            new Player("name", null)
        };

        players[0].PlayerFinishTurn();
        bool b = master.allAreDone(players.ToArray());
        Assert.IsTrue(b);
    }

    [Test]
    public void TestAllAreDone_False()
    {
        TurnMaster master = new TurnMaster();
        List<Player> players = new List<Player>
        {
            new Player("name", null)
        };

        bool b = master.allAreDone(players.ToArray());
        Assert.IsFalse(b);
    }

    [Test]
    public void TestNewTurn()
    {
        TurnMaster master = new TurnMaster();
        List<Player> players = new List<Player>
        {
            new Player("name", null)
        };

        master.newTurn(players.ToArray());
        Assert.IsTrue(!players[0].IsPlayerTurnFinished());
    }

    [Test]
    public void TestGetCurrTurn()
    {
        TurnMaster master = new TurnMaster();
        

        Assert.AreEqual(master.getCurrTurn(), 0);
    }
}

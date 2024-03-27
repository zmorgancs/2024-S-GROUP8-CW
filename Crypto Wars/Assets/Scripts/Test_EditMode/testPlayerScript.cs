using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//using Player;

namespace Test
{

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

    }
}
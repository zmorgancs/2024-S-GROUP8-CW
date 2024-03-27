using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest
{
    Card TestCard = new Card(null, "John");

    // Test get attack from card
    [Test]
    public void TestGetAttack()
    {
        TestCard.setOffense(10);
        Assert.AreEqual(10, TestCard.getOffense());

    }

    // Test get defense from card
    [Test]
    public void TestGetDefense()
    {
        TestCard.setDefense(10);
        Assert.AreEqual(10, TestCard.getDefense());

    }

    // Test get stamina from card
    [Test]
    public void TestGetStamina()
    {
        TestCard.setStaminaCost(10);
        Assert.AreEqual(10, TestCard.getStaminaCost());

    }

}

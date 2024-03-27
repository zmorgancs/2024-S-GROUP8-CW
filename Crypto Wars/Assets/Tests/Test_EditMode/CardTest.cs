using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest
{
    Card TestCard = new Card(null, "John");

    // A Test behaves as an ordinary method
    [Test]
    public void TestGetAttack()
    {
        TestCard.setOffense(10);
        Assert.AreEqual(10, TestCard.getOffense());

    }

    [Test]
    public void TestGetDefense()
    {
        TestCard.setDefense(10);
        Assert.AreEqual(10, TestCard.getDefense());

    }

    [Test]
    public void TestGetStamina()
    {
        TestCard.setStaminaCost(10);
        Assert.AreEqual(10, TestCard.getStaminaCost());

    }

}

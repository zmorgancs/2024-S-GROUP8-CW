using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTest
{
    [Test]
    public void TestGetCards()
    {
        Hand hand = new Hand();
        Card TestCard = new Card(null, "John");
        hand.AddCardtoHand(TestCard);
        List<Card> cards = hand.GetHandCards();
        Assert.AreEqual(cards.Count, 1);

    }

    [Test]
    public void TestRemoveCard()
    {
        Hand hand = new Hand();
        Card TestCard = new Card(null, "John");
        hand.AddCardtoHand(TestCard);
        List<Card> cards = hand.GetHandCards();
        Assert.AreEqual(cards.Count, 1);

        hand.RemoveCardfromHand(TestCard);
        Assert.AreEqual(cards.Count, 0);

    }

    [Test]
    public void TestCountTypeCard()
    {
        Hand hand = new Hand();
        Card TestCard = new Card(null, "John");
        hand.AddCardtoHand(TestCard);
        Assert.AreEqual(hand.CountofCardType(TestCard), 1);
    }

    [Test]
    public void TestEmpty()
    {
        Hand hand = new Hand();
        Assert.True(hand.IsEmpty());
    }
}

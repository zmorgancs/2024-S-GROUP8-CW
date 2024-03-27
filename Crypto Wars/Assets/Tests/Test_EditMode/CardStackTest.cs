using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardStackTest
{
    Card TestCard = new Card(null, "John");
    Card TestCard1 = new Card(null, "Steve");

    // A Test behaves as an ordinary method
    [Test]
    public void TestGetCardInStack()
    {
        CardStack stack = new CardStack(TestCard, 1);
        Card card = stack.GetCardinStack();

        Assert.AreEqual(card, TestCard);

    }

    [Test]
    public void TestCanAddtoStack_True()
    {   
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(true, stack.CanAddtoStack(TestCard));

    }

    [Test]
    public void TestCanAddtoStack_False()
    {
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(false, stack.CanAddtoStack(TestCard1));

    }

    [Test]
    public void TestAddCardtoStack_True()
    {
        CardStack stack = new CardStack(TestCard, 2);
        int originalSize = stack.GetSize();
        bool b = stack.AddCardtoStack(TestCard);

        Assert.AreEqual(true, b);
        Assert.AreEqual(originalSize + 1, stack.GetSize());

    }

    [Test]
    public void TestAddCardtoStack_False()
    {
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(false, stack.AddCardtoStack(TestCard1));

    }

    [Test]
    public void TestRemoveCardtoStack_True()
    {
        CardStack stack = new CardStack(TestCard, 2);
        int originalSize = stack.GetSize();
        bool b = stack.RemoveCardFromStack(TestCard);

        Assert.AreEqual(true, b);
        Assert.AreEqual(originalSize - 1, stack.GetSize());

    }

    [Test]
    public void TestRemoveCardtoStack_False()
    {
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(false, stack.RemoveCardFromStack(TestCard1));

    }

    [Test]
    public void TestIsFull()
    {
        CardStack stack = new CardStack(TestCard, 1);
        stack.CheckFullness();
        Assert.AreEqual(true, stack.IsFull());

    }


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerTest2()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

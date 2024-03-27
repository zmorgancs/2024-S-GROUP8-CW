using NUnit.Framework;

public class CardStackTest
{
    

    // Tests if a card is in the stack
    [Test]
    public void TestGetCardInStack()
    {
        Card TestCard = new Card(null, "John");
        CardStack stack = new CardStack(TestCard, 1);
        Card card = stack.GetCardinStack();

        Assert.AreEqual(card, TestCard);

    }

    // Tests if a card matches the card in the stack
    [Test]
    public void TestCanAddtoStack_True()
    {
        Card TestCard = new Card(null, "John");
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(true, stack.CanAddtoStack(TestCard));

    }

    // Tests if a incorrect card is ignored
    [Test]
    public void TestCanAddtoStack_False()
    {
        Card TestCard = new Card(null, "John");
        Card TestCard1 = new Card(null, "Steve");
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(false, stack.CanAddtoStack(TestCard1));

    }

    // Tests if a card will be added to a stack
    [Test]
    public void TestAddCardtoStack_True()
    {
        Card TestCard = new Card(null, "John");
        CardStack stack = new CardStack(TestCard, 2);
        int originalSize = stack.GetSize();
        bool b = stack.AddCardtoStack(TestCard);

        Assert.AreEqual(true, b);
        Assert.AreEqual(originalSize + 1, stack.GetSize());

    }

    // Tests if a incorrect card is ignored when added to a stack
    [Test]
    public void TestAddCardtoStack_False()
    {
        Card TestCard = new Card(null, "John");
        Card TestCard1 = new Card(null, "Steve");
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(false, stack.AddCardtoStack(TestCard1));

    }

    // Tests if a card can be removed from a stack
    [Test]
    public void TestRemoveCardtoStack_True()
    {
        Card TestCard = new Card(null, "John");
        CardStack stack = new CardStack(TestCard, 2);
        int originalSize = stack.GetSize();
        bool b = stack.RemoveCardFromStack(TestCard);

        Assert.AreEqual(true, b);
        Assert.AreEqual(originalSize - 1, stack.GetSize());

    }

    // Tests if an incorrect card is not remove from the stack
    [Test]
    public void TestRemoveCardtoStack_False()
    {
        Card TestCard = new Card(null, "John");
        Card TestCard1 = new Card(null, "Steve");
        CardStack stack = new CardStack(TestCard, 1);
        Assert.AreEqual(false, stack.RemoveCardFromStack(TestCard1));

    }

    // Tests if a stack can become full
    [Test]
    public void TestIsFull()
    {
        Card TestCard = new Card(null, "John");
        CardStack stack = new CardStack(TestCard, 1);
        stack.CheckFullness();
        Assert.AreEqual(true, stack.IsFull());

    }

}

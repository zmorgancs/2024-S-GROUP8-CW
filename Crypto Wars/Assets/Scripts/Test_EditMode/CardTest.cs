using NUnit.Framework;
public class CardTest
{
    // Test get attack from card
    [Test]
    public void TestGetAttack()
    {
        Card TestCard = new Card(null, "John");
        TestCard.setOffense(10);
        Assert.AreEqual(10, TestCard.getOffense());

    }

    // Test get defense from card
    [Test]
    public void TestGetDefense()
    {
        Card TestCard = new Card(null, "John");
        TestCard.setDefense(10);
        Assert.AreEqual(10, TestCard.getDefense());

    }

    // Test get stamina from card
    [Test]
    public void TestGetStamina()
    {
        Card TestCard = new Card(null, "John");
        TestCard.setStaminaCost(10);
        Assert.AreEqual(10, TestCard.getStaminaCost());

    }

}

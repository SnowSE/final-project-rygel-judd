namespace TestProgram;

using static Mechanics.Utilities;
using static Combat.Utilities;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DamageDealtTest() //DamageDealt test 1
    {
        int expected = 4;
        int actual = DamageDealt("Dagger", "Beginner's", 1);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void DamageDealtLegendary() //DamageDealt test 2
    {
        int expected = 10;
        int actual = DamageDealtTest("Axe", "Legendary", 10);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AttackOptionTestOneHanded()
    {
        int intActual;
        bool boolActual;

        (intActual, boolActual) = AttackOption("Dagger", "Beginner's", 1);
        ConsoleKey.A;

        int intExpected = 4;
        bool boolExpected = true;

        Assert.AreEqual(intActual, intExpected);
        Assert.AreEqual(boolActual, boolExpected);
    }

    [Test]
    public void AttackOptionTestTwoHanded()
    {
        int intActual;
        bool boolActual;

        (intActual, boolActual) = AttackOption("Dagger", "Beginner's", 1);
        ConsoleKey.B;

        int intExpected = 8;
        bool boolExpected = false;

        Assert.AreEqual(intActual, intExpected);
        Assert.AreEqual(boolActual, boolExpected);
    }

}
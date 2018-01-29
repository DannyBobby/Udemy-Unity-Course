using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest
{

    [Test]
    public void T00_PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_Bowl1()
    {
        int[] rolls = { 1 };
        string rollsString = "1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02_Strike()
    {
        int[] rolls = { 10 };
        string rollsString = "X ";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03_Spare()
    {
        int[] rolls = { 1, 9 };
        string rollsString = "1/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04_Bowl191()
    {
        int[] rolls = { 1, 9, 1};
        string rollsString = "1/1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05_SpareInFrame10()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 3};
        string rollsString = "1111111111111111111/3";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06_StrikeInFrame10()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 };
        string rollsString = "111111111111111111X11";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }


    [Test]
    public void T07_Bowl0()
    {
        int[] rolls = { 0 };
        string rollsString = "-";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T08_Bowl0Then10()
    {
        int[] rolls = { 0, 10 };
        string rollsString = "-/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}

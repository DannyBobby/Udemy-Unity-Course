//using NUnit.Framework;
//using System.Linq;


//[TestFixture]
//public class ActionMasterTest {

//    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
//    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
//    private ActionMaster.Action reset = ActionMaster.Action.Reset;
//    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;


//    [Test]
//	public void T01_OneStrikeReturnsEndTurn() {

//        int[] rolls = {10};
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//	}

//    [Test]
//    public void T02_Bowl8ReturnsTidy()
//    {
//        int[] rolls = {8};
//        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T03_Bowl8Then2ReturnsEndTurn()
//    {
//        int[] rolls = { 8, 2 };
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T04_CheckResetAtStrikeInLastFrame()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };                
//        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T05_CheckResetAtSpareInLastFrame()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
//        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T06_CheckGameEnds()
//    {
//        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
//        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T07_CheckGameEndsAtBowl20()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T08_TidyAfterStrikeOn19AndNoStrikeOn20()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1 };
        
//        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T09_TidyAfterStrikeOn19AndGutterOn20()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
//        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T10_BowlIndex()
//    {
//        int[] rolls = { 0, 10, 5, 1 };
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T11_Dondi10thFrameTurkey()
//    {
//        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
//        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//    }

//    [Test]
//    public void T12_ZeroOneGivesEndTurn()
//    {
//        int[] rolls = { 0, 1 };
//        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//    }
//}

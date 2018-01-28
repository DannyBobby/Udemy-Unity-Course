using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();

        for(int i = 0; i < rolls.Count; i+=2)
        {
            if(frameList.Count == 10) { break; } // This checks to make sure we aren't adding frames which 
                                                 // don't exist - such as when we get a strike on the last
                                                 // frame.

            if(rolls[i] == 10) // you got a strike!
            {
                if (rolls.Count > i + 2) // If you've completed the next two bowls, then tally the score.
                {
                    frameList.Add(rolls[i] + rolls[i + 1] + rolls[i + 2]);
                    i--; // we have to do this because we don't record a 0 for the second part of a frame.
                         // in reality, the second part of the frame just doesn't happen. The better you
                         // do in bowling, the quicker the game.
                }
                else break;
            }
            
            else if (rolls.Count - i > 1) // If the frame isn't "open"...
            {
                if((rolls[i] + rolls[i+1]) == 10) // ... and you have already picked up the spare...
                {
                    // ... and if you've completed the first bowl 
                    // of the next frame, then tally it.
                    if (rolls.Count - i >= 3) 
                    {
                        frameList.Add(rolls[i] + rolls[i + 1] + rolls[i + 2]);
                    }
                    else { break; } // otherwise don't do anything
                }
                else
                {
                    // no strike and no spare and the frame 
                    // is closed? tally it.
                    frameList.Add(rolls[i] + rolls[i + 1]); 
                }
            }
            else { break; }// If the frame is still "open", don't do anything

        }

        return frameList;
    }    
}

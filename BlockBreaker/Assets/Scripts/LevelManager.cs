using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Brick.breakableBrickCount = 0;
        Application.LoadLevel(name);        
    }

    public void LoadNextLevel()
    {
        Brick.breakableBrickCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableBrickCount <= 0)
        {
            LoadNextLevel();
        }
    }
}

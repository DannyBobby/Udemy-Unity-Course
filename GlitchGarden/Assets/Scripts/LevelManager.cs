using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadInterval;
    private int currentLevel = 0;
    private int previousLevel = 0;

    private MusicPlayer musicPlayer;

    #region public methods
    #region getters and setters
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetPreviousLevel()
    {
        return previousLevel;
    }
    #endregion

    public void LoadLevel(string name)
    {
        //Debug.Log("Level load requested for: " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    #endregion

    #region private methods
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (currentLevel == 0 && autoLoadInterval > 0)
        {
            Invoke("LoadNextLevel", autoLoadInterval);
        }
        else
        {
            Debug.LogError("Auto load disabled. Please enter an interval greater than zero seconds.");
        }

        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void OnLevelWasLoaded()
    {
        previousLevel = currentLevel;
        currentLevel = Application.loadedLevel;
        //Debug.Log("LEVEL MANAGER: Current level: " + currentLevel.ToString() + " & Previous level: " + previousLevel.ToString());

        if ((previousLevel == 1 && currentLevel == 2) || 
            (previousLevel == 2 && currentLevel == 1))
        { /* Don't change the music when transitioning between the start menu and the options menu. */ }
        else { musicPlayer.PlayTrack(currentLevel); }
    }
    #endregion
}

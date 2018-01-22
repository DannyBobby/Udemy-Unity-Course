using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY= "level_unlocked_";

    public static void SetMasterVolume(float volumeLevel)
    {
        if (volumeLevel > 0.0f && volumeLevel < 1.0f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volumeLevel);
        }
        else
        {
            Debug.LogError("Master volume level out of range.");
        }
    }

    public static float GetMasterVolume()
    {        
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, OptionsController.DEFAULT_VOLUME);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order.");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelStatus = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());

        if (level <= Application.levelCount - 1)
        {
            return (levelStatus == 1);
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order.");
            return false;
        }               
    }

    public static void SetDifficulty(int difficultyLevel)
    {
        if (difficultyLevel >= 1 && difficultyLevel <= 3)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficultyLevel);
        }
        else
        {
            Debug.LogError("Difficulty level must be an integer between 0 and 1 inclusive.");
        }
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY, OptionsController.DEFAULT_DIFFICULTY);
    }
}

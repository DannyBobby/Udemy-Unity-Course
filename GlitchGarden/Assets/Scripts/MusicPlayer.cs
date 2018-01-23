using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] private AudioClip[] soundtrack;
    private AudioSource music;

    #region public methods
    public void PlayTrack(int currentLevel)
    {
        AudioClip thisLevelMusic = soundtrack[currentLevel];

        if (thisLevelMusic) // null check
        {
            music.Stop();
            music.clip = thisLevelMusic;
            //Debug.Log("Music for level" + currentLevel.ToString() + " was loaded.");
            music.Play();
        }
        else
        {
            Debug.LogError("No music found for this level. Check the soundtrack array.");
        }
    }

    public void ChangeVolume(float volumeLevel)
    {
        if (volumeLevel >= 0f && volumeLevel <= 1f)
        {
            music.volume = volumeLevel;
        }
        else
        {
            Debug.LogError("MUSIC PLAYER ERROR: Volume level must be a value between 0 and 1 inclusive.");
        }
    }
    #endregion

    #region private methods
    void Awake ()
    {
        DontDestroyOnLoad(gameObject);        
    }	

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = soundtrack[0];
        music.loop = true;
        music.volume = PlayerPrefsManager.GetMasterVolume();
        //Debug.Log("MUSIC MANAGER: " + music.volume.ToString());

        music.Play();        
    }
    #endregion
}

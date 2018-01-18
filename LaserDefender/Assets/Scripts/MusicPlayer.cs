using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    [SerializeField] private AudioClip[] soundtrack;

    private AudioSource music;
    
	void Awake () {
	    if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }	

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = soundtrack[0];
        music.loop = true;
        music.Play();
    }

    void OnLevelWasLoaded(int level)
    {
        music.Stop();
        music.clip = soundtrack[level];
        Debug.Log("Music for level" + level.ToString() + " was loaded.");
        music.Play();
    }
}

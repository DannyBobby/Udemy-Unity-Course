using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour {

    [SerializeField] private float levelDuration;

    private LevelManager levelManager;
    private AudioSource audioSource;
    private Slider levelTimer;
    private float startTime;
    private bool isEndOfLevel = false;
    private GameObject winScreen;    

    // Use this for initialization
    void Start () {
        FindYouWin();
       
        levelManager = FindObjectOfType<LevelManager>();
        levelTimer = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();

        levelTimer.value = 0f;
        startTime = Time.timeSinceLevelLoad;
	}    

// Update is called once per frame
void Update () {
        float elapsedTime = Time.timeSinceLevelLoad - startTime;
        float percentageLevelComplete = (elapsedTime / levelDuration);
        
        levelTimer.value = percentageLevelComplete;

        if (elapsedTime >= levelDuration && !isEndOfLevel)
        {
            isEndOfLevel = true;

            DestroyAll();
            winScreen.SetActive(true);
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
	}

    void DestroyAll()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("destroyOnWin");

        foreach(GameObject o in obj)
        {
            Destroy(o);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    void FindYouWin()
    {
        winScreen = GameObject.Find("WinScreen");
        if (!winScreen)
        {
            Debug.LogWarning("Please create \"You Win!\" label");
        }
        else
        {
            winScreen.SetActive(false);
        }
    }
}

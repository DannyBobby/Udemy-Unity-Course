using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;

    private LevelManager levelManager;
    private MusicPlayer musicPlayer;

    public const float DEFAULT_VOLUME = 0.8f;
    public const int DEFAULT_DIFFICULTY = 2;

    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        musicPlayer = FindObjectOfType<MusicPlayer>();

        // Set options based on the player's saved preferences
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update () {
        musicPlayer.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty((int) difficultySlider.value);
        levelManager.LoadLevel("01a_Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = DEFAULT_VOLUME;
        difficultySlider.value = DEFAULT_DIFFICULTY;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {

    [SerializeField] float crossFadeDuration;
    private IEnumerator coroutine;

    void Start()
    {
        float waitDuration = FindObjectOfType<LevelManager>().autoLoadInterval - crossFadeDuration;
        coroutine = WaitAndFade(waitDuration);
        StartCoroutine(coroutine);
    }
    
    private IEnumerator WaitAndFade(float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        Image splashscreen = GetComponent<Image>();
        splashscreen.CrossFadeAlpha(0.0f, crossFadeDuration, false);        
    }
}

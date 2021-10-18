using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleDisplay : MonoBehaviour {

    [SerializeField] private Dialogger dialogger;
    [SerializeField] private TextMeshProUGUI text;
    public Color textColor;
    [SerializeField] private float fadeInTime, fadeOutTime;

    private Coroutine subtitles;

    private void Awake() {
        if(!dialogger)
            dialogger = FindObjectOfType<Dialogger>();
        if(dialogger)
            dialogger.onSubtitleChanged += (str, duration) => DisplaySubtitles(str, duration);

        if(!text)
            text = GetComponent<TextMeshProUGUI>();
        text.color = new Color32(255, 255, 255, 0);
    }

    public void DisplaySubtitles(string str, float duration) {
        if(subtitles == null) { // No subtitles being displayed
            Debug.Log("start new");
            subtitles = StartCoroutine(SubtitlesCoroutine(str, duration, true));
        } else { // Subtitles already being displayed
            Debug.Log("restart");
            StopCoroutine(subtitles);
            subtitles = StartCoroutine(SubtitlesCoroutine(str, duration, false));
        }
    }

    private IEnumerator SubtitlesCoroutine(string str, float duration, bool fadeIn = true, bool fadeOut = true) {
        text.text = str;
        byte r = (byte)(textColor.r * 255), g = (byte)(textColor.g * 255), b = (byte)(textColor.b * 255);

        if(fadeIn) {
            text.color = new Color32(r, g, b, 0);
            for(float i = 0; i < fadeInTime; i += Time.deltaTime) {
                text.color = new Color32(r, b, g, (byte)(i / fadeInTime * 255));
                yield return null;
            }
            duration -= fadeInTime;
        }
        text.color = new Color32(r, b, g, 255);

        if(fadeOut)
            duration -= fadeOutTime;
        if(duration > 0)
            yield return new WaitForSeconds(duration);

        if(fadeOut) {
            for(float i = fadeOutTime; i > 0; i -= Time.deltaTime) {
                text.color = new Color32(r, b, g, (byte)(i / fadeOutTime * 255));
                yield return null;
            }
        }
        text.color = new Color32(r, g, b, 0);
        subtitles = null;
    }

}

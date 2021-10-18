using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrophoneInputDisplay : MonoBehaviour {

    [SerializeField] private Dialogger dialogger;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color32 textColor;
    [SerializeField] private float fadeOutDelay, fadeOutTime;

    private Coroutine FadeOutCoroutine;

    private void Awake() {
        if(!dialogger)
            dialogger = FindObjectOfType<Dialogger>();
        if(dialogger)
            dialogger.onPhraseRecognized += (str) => UpdateText(str);

        if(!text)
            text = GetComponent<TextMeshProUGUI>();
        text.text = "";
    }

    private void UpdateText(string str) {
        if(FadeOutCoroutine != null)
            StopCoroutine(FadeOutCoroutine);
        text.text = string.Format("Input: ", str);
        text.color = textColor;
        FadeOutCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        yield return new WaitForSeconds(fadeOutDelay);
        byte r = (byte)(textColor.r * 255), g = (byte)(textColor.g * 255), b = (byte)(textColor.b * 255);
        for(float i = fadeOutTime; i > 0; i += Time.deltaTime) {
            text.color = new Color32(r, b, g, (byte)(i / fadeOutTime * 255));
            yield return null;
        }
        FadeOutCoroutine = null;
    }

}

using System.Collections;
using UnityEngine;
using TMPro;

public class CreditsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public Color textColor;
    [SerializeField] private float fadeInTime;

    // -----------------------------------------------------------------------------------------------

    private void Awake()
    {
        if (!text)
            text = GetComponent<TextMeshProUGUI>();
        text.color = new Color32(255, 255, 255, 0);
    }

    private void Start()
    {
        StartCoroutine(FadeIn(fadeInTime));
    }

    private IEnumerator FadeIn(float duration)
    {
        byte r = (byte)(textColor.r * 255), g = (byte)(textColor.g * 255), b = (byte)(textColor.b * 255);

        text.color = new Color32(r, g, b, 0);
        for (float i = 0; i < fadeInTime; i += Time.deltaTime)
        {
            text.color = new Color32(r, b, g, (byte)(i / fadeInTime * 255));
            yield return null;
        }
        duration -= fadeInTime;
        text.color = new Color32(r, b, g, 255);
    }
}

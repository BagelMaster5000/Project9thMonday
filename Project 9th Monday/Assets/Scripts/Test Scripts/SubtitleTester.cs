using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTester : MonoBehaviour {

    [SerializeField] private SubtitleDisplay display;
    [SerializeField] private List<string> str = new List<string>();
    [SerializeField] private List<float> time = new List<float>();

    private void Awake() {
        if(!display)
            display = FindObjectOfType<SubtitleDisplay>();
    }

    public void DisplayText(int index) {
        display.DisplaySubtitles(str[index], time[index]);
    }

}

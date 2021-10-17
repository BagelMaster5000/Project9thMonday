using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SubtitleTester))]
public class SubtitleTesterEditor : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        SubtitleTester subtitles = target as SubtitleTester;

        if(GUILayout.Button("Display Text 1")) {
            subtitles.DisplayText(0);
        }
        if(GUILayout.Button("Display Text 2")) {
            subtitles.DisplayText(1);
        }
        if(GUILayout.Button("Display Text 3")) {
            subtitles.DisplayText(2);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrophoneSelect : MonoBehaviour {

    public static string currentMic;

    [SerializeField] private TMP_Dropdown dropdown;

    private void Awake() {
        if(!dropdown)
            dropdown = GetComponent<TMP_Dropdown>();

        dropdown.onValueChanged.AddListener(_ => { UpdateMic(); });
        GetOptions();
        UpdateMic();
    }

    private void GetOptions() {
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach(string str in Microphone.devices)
            options.Add(str);

        dropdown.AddOptions(options);
    }

    public void UpdateMic() {
        currentMic = dropdown.captionText.text;
        Debug.Log(string.Format("Set mic to: <color=#00FFFF>{0}</color>", currentMic));
    }

}

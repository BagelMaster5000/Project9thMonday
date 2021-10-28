using UnityEngine;
using Ink.Runtime;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Collections;

public class Dialogger : MonoBehaviour
{
    // Story
    public TextAsset inkFile;
    static Story story;

    // Speech to Text
    private DictationRecognizer dictationRecognizer;
    float autoRestartDelayTimer = 5;
    float autoRestartDelay = 10;

    // Player Variables
    bool waitingForChoice = false;
    Coroutine advanceDialogAfterDelay;
    [SerializeField] float defaultLineDuration = 2;


    // Delegates
    public delegate void SubtitleDelegate(string str, float duration);
    public delegate void PhraseRecognizedDelegate(string str);
    public delegate void ChoicesDelegate(string[] choices);

    public SubtitleDelegate onSubtitleChanged;
    public PhraseRecognizedDelegate onPhraseRecognized;
    public ChoicesDelegate onChoicesChanged;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer(ConfidenceLevel.Low);
        dictationRecognizer.DictationResult += OnDictationResult;
        dictationRecognizer.AutoSilenceTimeoutSeconds = 10000;
        dictationRecognizer.InitialSilenceTimeoutSeconds = 10000;
        dictationRecognizer.Start();
        autoRestartDelayTimer = Time.time + autoRestartDelay;

        //onSubtitleChanged += (string curLine, float duration) => Debug.Log("<color=#FF0000>Dialog: </color>" + curLine);
        //onPhraseRecognized += (string curPhrase) => Debug.Log("<color=#00FF00>Dictation: </color> " + curPhrase);
        //onChoicesChanged += (string[] choices) =>
        //{
        //    for (int c = 0; c < choices.Length; c++)
        //        Debug.Log("Choice #" + (c + 1) + ": " + choices[c]);
        //};

        story = new Story(inkFile.text);
        if (story.canContinue)
            AdvanceStory();
    }
    private void OnDisable()
    {
        print("DISPOSED");
        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();

        AkSoundEngine.PostEvent("StopAllAudio", gameObject);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (Time.time > 1 && focus)
            RestartDictationRecognizer();
    }

    private void RestartDictationRecognizer()
    {
        print("Restarting Dictation Recognizer");

        autoRestartDelayTimer = Time.time + autoRestartDelay;

        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();

        dictationRecognizer = new DictationRecognizer(ConfidenceLevel.Low);
        dictationRecognizer.DictationResult += OnDictationResult;
        dictationRecognizer.AutoSilenceTimeoutSeconds = 10000;
        dictationRecognizer.InitialSilenceTimeoutSeconds = 10000;
        dictationRecognizer.Start();
    }

    private void Update()
    {
        // Regardless of how high the auto silence timeout is, the dictation recognizer still stops automatically so it needs to be restarted
        if (Application.isFocused && Time.time > autoRestartDelayTimer && dictationRecognizer.Status != SpeechSystemStatus.Running)
        {
            dictationRecognizer.Start();

            autoRestartDelayTimer = Time.time + autoRestartDelay;
        }

        //print(dictationRecognizer.Status);
    }

    void OnDictationResult(string dictationText, ConfidenceLevel confidence)
    {
        InvokePhraseRecognizedDelegate(dictationText);

        for (int c = 0; c < story.currentChoices.Count; c++)
        {
            if (story.currentChoices[c].text.ToLower() == "anything")
            {
                story.ChooseChoiceIndex(c);
                waitingForChoice = false;

                if (story.canContinue)
                    AdvanceStory();

                return;
            }

            string[] choiceKeywords = story.currentChoices[c].text.ToLower().Split('/');
            foreach (string k in choiceKeywords)
            {
                if (dictationText == k || dictationText.Contains(k))
                {
                    story.ChooseChoiceIndex(c);
                    waitingForChoice = false;

                    if (story.canContinue)
                        AdvanceStory();

                    return;
                }
            }
        }
    }



    public void AdvanceStory()
    {
        story.Continue();


        ParseTagsForAudioEvents();

        float lineDuration = ParseTagsForLineDuration();
        if (advanceDialogAfterDelay != null)
            StopCoroutine(advanceDialogAfterDelay);
        advanceDialogAfterDelay = StartCoroutine(AdvanceOrLoopAfterDelay(lineDuration));


        InvokeSubtitleDelegate(story.currentText, lineDuration);
        InvokeChoicesDelegate(story.currentChoices);
    }
    void FinishStory() { } // FIXME Put an end behavior such as loading next scene


    IEnumerator AdvanceOrLoopAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        if (story.canContinue)
            AdvanceStory();
        else if (waitingForChoice)
        {
            story.ChooseChoiceIndex(0); // First choice at every break point is the silent option
            waitingForChoice = false;

            if (story.canContinue)
                AdvanceStory();
        }
        else
            FinishStory();
    }

    void ParseTagsForAudioEvents()
    {
        for (int t = 0; t < story.currentTags.Count; t++)
        {
            if (story.currentTags[t].Split(' ')[0] == "wwise")
            { 
                string eventToPost = story.currentTags[t].Split(' ')[1];
                //Debug.Log("Posting Event " + eventToPost);
                AkSoundEngine.PostEvent(eventToPost, gameObject);
                break;
            }
        }
    }

    float ParseTagsForLineDuration()
    {
        float lineDuration = defaultLineDuration;
        for (int t = 0; t < story.currentTags.Count; t++)
        {
            if (float.TryParse(story.currentTags[t], out float tempLineDuration))
            {
                lineDuration = tempLineDuration;
                break;
            }
        }

        return lineDuration;
    }



    private void InvokePhraseRecognizedDelegate(string dictationText)
    {
        if (onPhraseRecognized != null)
            onPhraseRecognized(dictationText);
    }

    void InvokeSubtitleDelegate(string curLine, float lineDuration)
    {
        if (onSubtitleChanged != null)
            onSubtitleChanged(curLine, lineDuration);
    }

    void InvokeChoicesDelegate(List<Choice> curChoices)
    {
        if (curChoices.Count > 0 && !waitingForChoice)
        {
            waitingForChoice = true;

            if (onChoicesChanged != null)
            {
                string[] choiceTexts = new string[story.currentChoices.Count];
                for (int c = 0; c < choiceTexts.Length; c++)
                    choiceTexts[c] = story.currentChoices[c].text.Split('/')[0];
                onChoicesChanged(choiceTexts);
            }
        }
    }
}


// Old code
//void ShowChoices()
//{
//    List<Choice> choices = story.currentChoices;

//    // Throws error if more choices than available buttons
//    if (choices.Count > buttons.Length)
//    {
//        Debug.LogError("More choices than buttons");
//        return;
//    }

//    madeDecision = false;

//    // Sets buttons
//    for (int x = 0; x < choices.Count; x++)
//    {
//        buttons[x].transform.GetComponentInChildren<TextMeshProUGUI>().text = choices[x].text;
//        buttons[x].GetComponent<Selectable>().element = choices[x];
//        buttons[x].SetActive();
//    }
//}
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

    // Player Variables
    bool waitingForChoice = false;
    Coroutine advanceDialogAfterDelay;


    // Delegates
    public delegate void SubtitleDelegate(string str, float duration);
    public delegate void PhraseRecognizedDelegate(string str);
    public delegate void ChoicesDelegate(List<Choice> choices);

    public SubtitleDelegate onSubtitleChanged;
    public PhraseRecognizedDelegate onPhraseRecognized;
    public ChoicesDelegate onChoicesChanged;

    void Start()
    {
        //Debug.Log("<color=#00FF00>Say \"Advance\" to progress the story!</color>");

        dictationRecognizer = new DictationRecognizer(ConfidenceLevel.Low);
        dictationRecognizer.DictationResult += OnDictationResult;
        dictationRecognizer.AutoSilenceTimeoutSeconds = Mathf.Infinity;
        dictationRecognizer.InitialSilenceTimeoutSeconds = Mathf.Infinity;
        dictationRecognizer.Start();

        onSubtitleChanged += (string curLine, float duration) => Debug.Log("<color=#FF0000>Dialog: </color>" + curLine);
        onPhraseRecognized += (string curPhrase) => Debug.Log("<color=#00FF00>Dictation: </color> " + curPhrase);
        onChoicesChanged += (List<Choice> choices) =>
        {
            for (int c = 0; c < choices.Count; c++)
                Debug.Log("Choice #" + (c + 1) + ": " + choices[c].text);
        };

        story = new Story(inkFile.text);
        if (story.canContinue)
            AdvanceStory();
    }
    private void OnDisable()
    {
        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();
    }

    void OnDictationResult(string dictationText, ConfidenceLevel confidence)
    {
        InvokePhraseRecognizedDelegate(dictationText);

        string[] allWordsDictated = dictationText.Split(' ');
        foreach (string w in allWordsDictated)
        {
            if (w == "advance") // Placeholder, final game should advance story automatically
            {
                if (story.canContinue && !waitingForChoice)
                    AdvanceStory();
                else if (!waitingForChoice)
                    FinishStory();
                return;
            }

            for (int c = 0; c < story.currentChoices.Count; c++)
            {
                if (story.currentChoices[c].text.ToLower().Contains(w))
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



    void AdvanceStory()
    {
        story.Continue();
        ParseTags();
        InvokeSubtitleDelegate(story.currentText);
        InvokeChoicesDelegate(story.currentChoices);
    }
    void FinishStory() { } // FIXME Put an end behavior such as loading next scene


    IEnumerator AdvanceOrLoopAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        if (story.canContinue)
            AdvanceStory();
        else if (!waitingForChoice)
            LoopCurrentLine(delay);
        else
            FinishStory();
    }

    private void LoopCurrentLine(float delay)
    {
        InvokeSubtitleDelegate(story.currentText);
        InvokeChoicesDelegate(story.currentChoices);
        if (advanceDialogAfterDelay != null)
            StopCoroutine(advanceDialogAfterDelay);
        advanceDialogAfterDelay = StartCoroutine(AdvanceOrLoopAfterDelay(delay));
    }


    void ParseTags()
    {
        if (story.currentTags.Count == 0)
            return;

        foreach (string t in story.currentTags)
        {
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "dur":
                    float.TryParse(param, out float delay);
                    if (delay == 0) // If dur parameter is 0, mising, or invalid
                        delay = 2;

                    if (advanceDialogAfterDelay != null)
                        StopCoroutine(advanceDialogAfterDelay);
                    advanceDialogAfterDelay = StartCoroutine(AdvanceOrLoopAfterDelay(delay));
                    break;
                case "wwise":
                    // Post Wwise event here
                    break;
            }
        }
    }



    private void InvokePhraseRecognizedDelegate(string dictationText)
    {
        if (onPhraseRecognized != null)
            onPhraseRecognized(dictationText);
    }

    void InvokeSubtitleDelegate(string curLine)
    {
        if (onSubtitleChanged != null)
            onSubtitleChanged(curLine, 2);
    }

    void InvokeChoicesDelegate(List<Choice> curChoices)
    {
        if (curChoices.Count > 0 && !waitingForChoice)
        {
            waitingForChoice = true;
            if (onChoicesChanged != null)
                onChoicesChanged(curChoices);
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
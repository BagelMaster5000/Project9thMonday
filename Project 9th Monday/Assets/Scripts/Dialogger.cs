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
        dictationRecognizer.AutoSilenceTimeoutSeconds = 10000;
        dictationRecognizer.InitialSilenceTimeoutSeconds = 10000;
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

    private void Update()
    {
        // Regardless of how high the auto silence timeout is, the dictation recognizer still stops itself so it needs to be restarted
        if (dictationRecognizer.Status != SpeechSystemStatus.Running)
            dictationRecognizer.Start();

        // print(dictationRecognizer.Status);
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

            for (int c = 1; c < story.currentChoices.Count; c++)
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
        else if (waitingForChoice)
        {
            story.ChooseChoiceIndex(0);
            waitingForChoice = false;

            if (story.canContinue)
                AdvanceStory();
        }
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
        float delay = 2;
        if (story.currentTags.Count > 0)
            float.TryParse(story.currentTags[0], out delay);

        if (advanceDialogAfterDelay != null)
            StopCoroutine(advanceDialogAfterDelay);
        advanceDialogAfterDelay = StartCoroutine(AdvanceOrLoopAfterDelay(delay));


        if (story.currentTags.Count > 1)
        {
            for (int t = 1; t < story.currentTags.Count; t++)
            {
                string prefix = story.currentTags[t].Split(' ')[0];
                string param = story.currentTags[t].Split(' ')[1];

                switch (prefix.ToLower())
                {
                    case "wwise":
                        // Post Wwise event here
                        break;
                }
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

            curChoices.RemoveAt(0);
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
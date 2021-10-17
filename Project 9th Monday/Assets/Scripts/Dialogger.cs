using UnityEngine;
using Ink.Runtime;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class Dialogger : MonoBehaviour
{
    [Header("Story")]
    public TextAsset inkFile;
    static Story story;

    bool waitingForChoice = false;

    // Voice Inputs
    private DictationRecognizer dictationRecognizer;

    // Delegates
    public delegate void SubtitleDelegate(string str, float duration);
    public delegate void PhraseRecognizedDelegate(string str);
    public delegate void ChoicesDelegate(List<Choice> choices);

    public SubtitleDelegate onSubtitleChanged;
    public PhraseRecognizedDelegate onPhraseRecognized;
    public ChoicesDelegate onChoicesChanged;

    private void Awake()
    {
        
    }

    private void OnDisable()
    {
        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();
    }

    void Start()
    {
        Debug.Log("<color=#00FF00>Say \"Advance\" to progress the story!</color>");

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
        ContinueStory();
    }

    void OnDictationResult(string text, ConfidenceLevel confidence)
    {
        if (onPhraseRecognized != null)
            onPhraseRecognized(text);

        string[] allWordsDictated = text.Split(' ');
        foreach (string w in allWordsDictated)
        {
            if (w == "advance") // Placeholder, final game should advance story automatically
            {
                ContinueStory();
                return;
            }

            for (int c = 0; c < story.currentChoices.Count; c++)
            {
                if (story.currentChoices[c].text.ToLower().Contains(w))
                {
                    story.ChooseChoiceIndex(c);
                    AdvanceFromDecision();
                    return;
                }
            }
        }
    }

    // Advances dialog if able. Otherwise, ends story
    public void ContinueStory()
    {
        if (story.canContinue && !waitingForChoice)
            AdvanceDialog();
        else if (!waitingForChoice)
            FinishDialog();
    }

    void AdvanceDialog()
    {
        string curSentence = story.Continue();
        ParseTags();
        ShowDialog(curSentence);
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
                //case "anim":
                //    SetAnimation(param);
                //    break;
            }
        }
    }

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
    //    }
    //    buttonAnimator.Appear(choices.Count);
    //}

    void FinishDialog()
    {
        // FIXME Put an end behavior such as loading next scene
    }

    void AdvanceFromDecision()
    {
        waitingForChoice = false;

        if (story.canContinue)
            AdvanceDialog();
    }

    void ShowDialog(string curLine)
    {
        if (onSubtitleChanged != null)
            onSubtitleChanged(curLine, 2);

        if (story.currentChoices.Count > 0)
        {
            waitingForChoice = true;
            if (onChoicesChanged != null)
                onChoicesChanged(story.currentChoices); // Show choices
        }
    }
}

using System.Collections;
using UnityEngine;
using TMPro;

public class TextBoxSystem : MonoBehaviour
{
    public static TextBoxSystem instance;

    public ELEMENTS elements;

    void Awake() {
        instance = this;
    }

    public void Say(string speech) {
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech, false));
    }

    public void SayAdd(string speech) {
        StopSpeaking();

        speechText.text = targetSpeech;

        speaking = StartCoroutine(Speaking(speech, true));
    }

    public void StopSpeaking() {
        if (isSpeaking) {
            StopCoroutine(speaking);
        }
        if (textArchitect != null && textArchitect.isConstructiong) {
            textArchitect.Stop();
        }
        speaking = null;
    }

    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitingForUserInput = false;

    string targetSpeech = "";
    Coroutine speaking = null;
    TextArchitect textArchitect = null;
    IEnumerator Speaking(string speech, bool additive) {
        textPanel.SetActive(true);

        string additiveSpeech = additive ? speechText.text : "";
        targetSpeech = additiveSpeech + speech;

        textArchitect = new TextArchitect(speech, additiveSpeech);

        isWaitingForUserInput = false;

        while(textArchitect.isConstructiong) {
            if (Input.GetKey(KeyCode.Mouse0))
                textArchitect.skip = true;

            speechText.text = textArchitect.currentText;

            yield return new WaitForEndOfFrame();
        }

        speechText.text = textArchitect.currentText;
        //text finished
        isWaitingForUserInput = true;

        while (isWaitingForUserInput)
            yield return new WaitForEndOfFrame();

        StopSpeaking();
    }

    [System.Serializable]
    public class ELEMENTS {
        public GameObject textPanel;
        public TextMeshProUGUI speechText;
    }
    public GameObject textPanel { get { return elements.textPanel; } }
    public TextMeshProUGUI speechText { get { return elements.speechText;  } }
}

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

    // Start is called before the first frame update
    void Start(){
        
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
        speaking = null;
    }

    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitingForUserInput = false;

    string targetSpeech = "";
    Coroutine speaking = null;
    IEnumerator Speaking(string speech, bool additive) {
        textPanel.SetActive(true);
        targetSpeech = speech;
        if (!additive)
            speechText.text = "";
        else
            targetSpeech = speechText.text + targetSpeech;
        isWaitingForUserInput = false;

        while(speechText.text != targetSpeech) {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }

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

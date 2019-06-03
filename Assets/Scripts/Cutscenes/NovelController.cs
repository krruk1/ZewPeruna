using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelController : MonoBehaviour
{
    TextBoxSystem textBox;
    List<string> data = new List<string>();
    int progress = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadChapterFile("intro");
        textBox = TextBoxSystem.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            HandleLine(data[progress]);
            progress++;
        }
    }

    public void LoadChapterFile(string fileName) {
        data = FileManager.LoadFile(FileManager.savPath + "Story/" + fileName);
        progress = 0;
    }

    void HandleLine(string line) {
        string[] dialogueAndActions = line.Split('"');

        if (dialogueAndActions.Length == 3) {
            HandleDialogue(dialogueAndActions[0], dialogueAndActions[1]);
            HandleEventsFromLine(dialogueAndActions[2]);
        }
        else {
            HandleEventsFromLine(dialogueAndActions[0]);
        }
    }

    void HandleDialogue(string dialogueDetails, string dialogue) {
        bool additive = dialogueDetails.Contains("+");

        if (additive)
            textBox.SayAdd(dialogue);

        textBox.Say(dialogue);

    }

    void HandleEventsFromLine(string events) {
        string[] actions = events.Split(',');

        foreach(string action in actions) {
            HandleAction(action);
        }
    }

    void HandleAction(string action) {
        print("Handle action [" + action + "]");
        string[] data = action.Split('(', ')');

        if (data[0] == "playSound"){
            Command_PlaySound(data[1]);
            return;
        }
        if (data[0] == "playMusic") {
            Command_PlayMusic(data[1]);
            return;
        }
    }

    void Command_PlaySound(string data) {
        AudioClip clip = Resources.Load("SFX/" + data) as AudioClip;
        if (clip != null)
            AudioManager.instance.PlaySFX(clip);
        else
            Debug.LogError("Clip does not exist - " + data);
    }

    void Command_PlayMusic(string data) {
        AudioClip clip = Resources.Load("Music/" + data) as AudioClip;
        if (clip != null)
            AudioManager.instance.PlaySong(clip);
        else
            Debug.LogError("Clip does not exist - " + data);
    }
}
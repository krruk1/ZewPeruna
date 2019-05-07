using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    TextBoxSystem dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = TextBoxSystem.instance;
    }

    public string[] s = new string[]{
        "Zawżdy była to ",
        "nie najlepsza noc.\n",
        "Doprawydż nie wiem, ",
        "jak to elegancko przetestować. ",
        "A jest już późno... A to dopiero początek \"zabawy\" heh.\n",
        "Teraz tylko pozostaje nie zasnąć...\n",
        "Nie myśleć o spannn...\n",
        "Z\n Z\n  Z\n   Z\n    Z\n     Z\n      Z\n       Z\n        Z\n         Z" +
        "\n          Z\n           Z\n            Z\n             Z\n              Z\n..."
    };
    int indx = 0;
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput) {
                if (indx >= s.Length) {
                    dialogue.Say("Nie mam pomysłu jak dobrze ogarnąć to ściernisko, ale kiedyś będzie to San Francisco.");
                    return;
                }
                dialogue.SayAdd(s[indx]);
                indx++;
            }
        }
    }

/*
    void Say(string s) {
//        dialogue.Say(s);
        dialogue.SayAdd(s);
    }
*/
}

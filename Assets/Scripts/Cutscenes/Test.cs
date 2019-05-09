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
        "Zawzdy byla to ",
        "<b>nie najlepsza</b> noc.\n",
        "Doprawydz nie wiem, ",
        "jak to <i>elegancko</i> przetestowac. ",
        "A jest juz pozno... A to dopiero poczatek <size=18><b>\"zabawy\"</b></size> heh.\n",
        "Teraz tylko pozostaje nie <color=red><size=30>zasnac</size></color>...\n",
        "Nie myslec o spannn...\n",
        "Z\n Z\n  Z\n   Z\n    Z\n     Z\n      Z\n       Z\n        Z\n         Z" +
        "\n          Z\n           Z\n            Z\n             Z\n              Z\n..."
    };
    public string dd = "Nie mam pomyslu jak dobrze ogarnac to <color=red><b>sciernisko</b></color>, ale kiedys bedzie to <color=green><b>San Francisco</b></color>.";
    int indx = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {
                if (indx >= s.Length)
                {
                    dialogue.Say(dd);
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
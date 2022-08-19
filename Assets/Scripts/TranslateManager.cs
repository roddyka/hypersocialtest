using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateManager : MonoBehaviour
{
   // Start is called before the first frame update
    public static TranslateManager instance;
    //false English, true Portuguese;
    private int translate;

    public string[] Play;
    public string[] Mutiplayer;
    public string[] Credits;
    public string[] Quit;

    //introduction Text
    public string[] text1;
    public string[] text2;
    public string[] text3;
    public string[] text4;
    void Start()
    {
        instance = this;
        translate = GameController.instance.language;
    }
}

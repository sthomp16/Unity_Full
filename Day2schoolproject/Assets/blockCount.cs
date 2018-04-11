using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockCount : MonoBehaviour {

    public int blockA;
    public int blockB;
    public int blockC;
    public int blockD;
    public Text ACount;
    public Text BCount;
    public Text CCount;
    public Text DCount;
    // Use this for initialization
    void Start()
    {
        blockA = 0;
        blockB = 0;
        blockC = 0;
        blockD = 1;
        SetBlockText();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void SetBlockText()
    {
        ACount.text = "Grass:  " + blockA.ToString();
        BCount.text = "Stone:  " + blockB.ToString();
        CCount.text = "Snow:  " + blockC.ToString();
        DCount.text = "Battery:  " + blockD.ToString();
        // if (ACount >= 100)
        // {
        //    winText.text = "You can go home";
        // }
    }
}

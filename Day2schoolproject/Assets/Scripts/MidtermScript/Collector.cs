using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour {

    public Text countText;
    public Text winText;

    public int count;
    public static int gateKeeper;
    // Use this for initialization
    void Start () {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powercell"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            // set variable to be usable by other scripts
            gateKeeper = count;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Powercell collection:  " + count.ToString();
        if (count >= 7)
        {
            winText.text = "You can go home";
        }
    }
}

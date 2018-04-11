using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cannonball : MonoBehaviour
{
    public Text LossText;
    public Text HPText;
    // public int hp;


    private void Start()
    {

        SetupText();
        LossText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
            GameObject go = other.gameObject;
            
            if (go.tag == "Player")
            {
                Debug.Log("The player was hit!");
                Collector.hp = Collector.hp - 1;
                SetupText();
                Destroy(gameObject); // destroy this cannonball when it hit the car.
            }
    }

    void SetupText()
    {
        
        HPText.text = "HP:  " + Collector.hp.ToString();
        if (Collector.hp <= 0)
        {
            LossText.text = "You are too damaged";
        }
    }
}
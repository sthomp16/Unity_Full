using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestBlock : MonoBehaviour {

    const float maxDestroyDistance = 10f;

    public static int blockA; // Dirt
    public static int blockB; // Stone
    public static int blockC; // Snow
    // victory condition variables
    public int VRR;
    public int VSR;
    // Crafting table resources converted to shorthand variables for win condition
    private int Iron = CraftingTable.rIron;
    private int Gold = CraftingTable.rGold;
    private int Electric = CraftingTable.rElectric;
    private int Battery = CraftingTable.rBattery;

    public Text ACount;
    public Text BCount;
    public Text CCount;

    // public Text DCount; // may need to remove for crafting table script
    public Text winText;
    public Text scoreText;

    // int Blockharvested = 0;
    private double score = 1000;

    void Start()
    {
        blockA = 0;
        blockB = 0;
        blockC = 0;
        // blockD = 1;
        SetBlockText();
        winText.text = "";
        scoreText.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        score -= .02;
        if (Input.GetMouseButtonDown(0) && CraftingTable.delim != 1)
        {
            Vector3 scrCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0); // Note use xy cord
            Ray ray = Camera.main.ScreenPointToRay(scrCenter);
            RaycastHit hit ;
            if (Physics.Raycast(ray, out hit, maxDestroyDistance))
            {
                if (hit.rigidbody== null)
                {
                    Debug.Log("hit something without rigidbody");
                    return;
                }
                GameObject go = hit.rigidbody.gameObject;

                // Get tag of object, add it to proper count
                if (go.tag == "ResourceA") 
                 {
                  // ++ player harvest count of blockA
                  blockA = blockA + 1;
                  //Debug.Log("The player has harvested dirt!");
                  Destroy(hit.transform.gameObject);
                 }
                 if (go.tag == "ResourceB") 
                 {
                //  ++ player harvest count of blockB
                  blockB = blockB + 1;
                  //Debug.Log("The player has harvested Stone!");
                  Destroy(hit.transform.gameObject);
                 }
                 if (go.tag == "ResourceC") 
                 {
                //  ++ player harvest count of blockC
                  blockC = blockC + 1;
                    //Debug.Log("The player has harvested snow!");
                    Destroy(hit.transform.gameObject);
                 }
                 if (go.tag == "NonDestructable") 
                 {
                  //Debug.Log("The player attempted harvesting lava");
                 }
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                SetBlockText();
                // Destroy(hit.transform.gameObject);

            }
        }
    }

    private void SetBlockText()
    {
        if (ACount == null)
        {
            Debug.Log("ACount is null!!!!");
        }
        ACount.text = "Grass:  " + blockA.ToString();
        BCount.text = "Stone:  " + blockB.ToString();
        CCount.text = "Snow:  " + blockC.ToString();
        // DCount.text = "Battery:  " + blockD.ToString();
        if (blockA >= 15 && blockB >= 15 && blockC >= 10)
        {
            VRR = 5;
            Debug.Log("All prerequisite regular resources aquired");
        }
        if (Iron > 10 && Gold > 10 && Electric > 10 && Battery > 5)
        {
            VSR = 5;
            Debug.Log("All prerequisite regular resources aquired");
        }

            if (VRR + VSR == 10)
        {
            Debug.Log("All prerequisite resources aquired");
            winText.text = "You can go home";
            scoreText.text = "Your score: " + score.ToString("0.00");
        }
    } // End SetBlockText
} // End public class HarvestBlock

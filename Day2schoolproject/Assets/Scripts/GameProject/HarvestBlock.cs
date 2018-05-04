using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestBlock : MonoBehaviour {

    const float maxDestroyDistance = 10f;

    public static int blockA; // Dirt
    public static int blockB; // Stone
    public static int blockC; // Snow

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
        Debug.Log("Require 15 Grass, and Stone And 10 snow. \n Other requirements: 10 Iron,Gold, Electric & 5 Battery");
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

    public void SetBlockText()
    {
        if (ACount == null)
        {
            Debug.Log("ACount is null!!!!");
        }
        ACount.text = "Grass:  " + blockA.ToString();
        BCount.text = "Stone:  " + blockB.ToString();
        CCount.text = "Snow:  " + blockC.ToString();
        // DCount.text = "Battery:  " + blockD.ToString();
        if (blockA >= 15 && blockB >= 15 && blockC >= 10 && CraftingTable.rIron >= 10 && CraftingTable.rGold >= 10 && CraftingTable.rElectric >= 10 && CraftingTable.rBattery >= 5)
        {
            Debug.Log("All prerequisite resources aquired");
            winText.text = "You can go home";
            scoreText.text = "Your score: " + score.ToString("0.00");
        }
    } // End SetBlockText
} // End public class HarvestBlock

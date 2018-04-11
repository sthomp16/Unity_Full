using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestBlock : MonoBehaviour {

    const float maxDestroyDistance = 10f;

    public int blockA;
    public int blockB;
    public int blockC;
    public int blockD;
    public Text ACount;
    public Text BCount;
    public Text CCount;
    public Text DCount;
    public Text winText;

    int Blockharvested = 0;

    void Start()
    {
        blockA = 0;
        blockB = 0;
        blockC = 0;
        blockD = 1;
        winText.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                  Debug.Log("The player has harvested dirt!");
                  Destroy(hit.transform.gameObject);
                 }
                 if (go.tag == "ResourceB") 
                 {
                //  ++ player harvest count of blockB
                  blockB = blockB + 1;
                  Debug.Log("The player has harvested Stone!");
                  Destroy(hit.transform.gameObject);
                 }
                 if (go.tag == "ResourceC") 
                 {
                //  ++ player harvest count of blockC
                  blockC = blockC + 1;
                    Debug.Log("The player has harvested snow!");
                    Destroy(hit.transform.gameObject);
                 }
                 if (go.tag == "NonDestructable") 
                 {
                  Debug.Log("The player attempted harvesting lava");
                 }
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
        DCount.text = "Battery:  " + blockD.ToString();
        if (blockA >= 10 && blockB >=10 && blockC >=10)
        {
            Debug.Log("All prerequisite resources aquired");
            winText.text = "You can go home";
        }
    } // End SetBlockText
} // End public class HarvestBlock

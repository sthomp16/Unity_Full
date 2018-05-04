using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class CraftingTable : MonoBehaviour {
    // Declared buttons to enable crafting
    public Button btnIron;
    public Button btnGold;
    public Button btnElectric;
    public Button btnBattery;
    public Button btnUseBattery;

    public static int rIron;
    public static int rGold;
    public static int rElectric;
    public static int rBattery;
    // deliminator for mouse lock state and camera state
    public static int delim;


    CursorLockMode wantedMode;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController scriptToggle;

    //public Camera playerView;

    // Special resource variables
    public Text Iron;
    public Text Gold;
    public Text Electric;
    public Text Battery;
    // special resource texts
    public Text ACount;
    public Text BCount;
    public Text CCount;

    // Use this for initialization
    void Start () {
        delim = 0;
        // Setting text for special resources
        Iron.text = "Iron: 0";
        Gold.text = "Gold: 0";
        Electric.text = "Electric: 0";
        // Battery.text = "0";
        rIron = 0;
        rGold = 0;
        rElectric = 0;
        rBattery = 1;
        Battery.text = rBattery.ToString();
        // These two should set the mouse properly at the start, don't know why I needed 2
        SetCursorState(delim);
        SetCursorState(delim);
        // listeners for buttons
        btnIron.onClick.AddListener(btnIronOnClick);
        btnGold.onClick.AddListener(btnGoldOnClick);
        btnElectric.onClick.AddListener(btnElectricOnClick);
        btnBattery.onClick.AddListener(btnBatteryOnClick);
        btnUseBattery.onClick.AddListener(btnUseBatteryOnClick);
        scriptToggle = GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {    
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            delim = 1;
            // Debug.Log("keycode recognition works");
            Debug.Log("Disable first person controll");
            // Camera.main.GetComponent<FirstPersonController>().enabled = false;
            //scriptToggle.enabled = false;

            //Camera.main.GetComponent<MouseLook>().lockCursor = false;
            // calls twice as this is fighting with the unreachable firstpersoncontroller.
            //Camera.main.enabled = false;
            SetCursorState(delim);
            SetCursorState(delim);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            delim = 0;
            Debug.Log("Enable first person controll");
            //Camera.main.GetComponent<MouseLook>().lockCursor = true;
            //scriptToggle.enabled = true;
            // Debug.Log("Closing menu");
            //Camera.main.enabled = true;
            SetCursorState(delim);
            SetCursorState(delim);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            hpDrain.health += 9999999;
            Debug.Log("Godmode aquired, press key additional times for more health");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            hpDrain.health = 100;
            Debug.Log("Deactivated Godmode or reset to normal health");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Wandering mouse without menu");
            SetCursorState(1);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Gain resources: ALL OF THEM");
            HarvestBlock.blockA += 10;
            HarvestBlock.blockB += 10;
            HarvestBlock.blockC += 10;
            rIron += 10;
            rGold += 10;
            rElectric += 10;
            rBattery += 10;
        }

    }
    // Apply requested cursor state
    void SetCursorState(int mouse)
    {
        Cursor.lockState = wantedMode;
        if (mouse == 1)
        {
            // Debug.Log("Mouse is free");
            wantedMode = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (mouse != 1)
        {
            // Debug.Log("Mouse is caged");
            wantedMode = CursorLockMode.Locked;
            // Hide cursor when locking
            Cursor.visible = (CursorLockMode.Locked != wantedMode);
            
        }
    }
    
    void btnIronOnClick()
    {
        if (HarvestBlock.blockA >= 4)
        {
            HarvestBlock.blockA = HarvestBlock.blockA - 4;
            rIron++;
            Debug.Log("rIron = " + rIron);
            Iron.text = "Iron: " + rIron.ToString();
            SetBlockText();
        }
        else
        {
            Debug.Log("Iron cost is 4 Dirt ");
            Debug.Log("Player attempted to generate resource without sufficent material");
        }
    }
    void btnGoldOnClick()
    {
        
        if (HarvestBlock.blockB >= 5)
        {
            HarvestBlock.blockB = HarvestBlock.blockB - 5;
            rGold++;
            Debug.Log("rGold = " + rGold);
            Gold.text = "Gold: " + rGold.ToString();
            SetBlockText();
        }
        else
        {
            Debug.Log("Gold cost is 5 stone ");
            Debug.Log("Player attempted to generate resource without sufficent material");
        }
        
    }
    void btnElectricOnClick()
    {
        if (HarvestBlock.blockC >= 2)
        {
            HarvestBlock.blockC = HarvestBlock.blockC - 2;
            rElectric += 2;
            Debug.Log("rElectric = " + rElectric);
            Electric.text = "Electric: " + rElectric.ToString();
            SetBlockText();
        }
        else
        {
            Debug.Log("Electric cost is 2 snow ");
            Debug.Log("Player attempted to generate resource without sufficent material");
        }

        
        
    }
    void btnBatteryOnClick()
    {
        if (rIron >= 2 && rGold >= 2 && rElectric >=2)
        {
            rIron = rIron - 2;
            rGold = rGold - 2;
            rElectric = rElectric - 2;
            rBattery++;
            Debug.Log("rBattery = " + rBattery);
            Electric.text = "Electric: " + rElectric.ToString();
            Iron.text = "Iron: " + rIron.ToString();
            Gold.text = "Gold: " + rGold.ToString();
            Battery.text = "Battery:  " + rBattery.ToString();
            SetBlockText();
        }
        else
        {
            Debug.Log("Gold cost is 2 iron, gold, and electric");
            Debug.Log("Player attempted to generate resource without sufficent material");
        }

    }
    void btnUseBatteryOnClick()
    {
        if (rBattery >= 1)
        {
            rBattery-= 1;
            // play audio
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Battery.text = "Battery:  " + rBattery.ToString();
            if (hpDrain.health <= 100)
            {
                hpDrain.health = 101;
            }
                
        }
        else
        {
            Debug.Log("Need a battery to use one.");
            Debug.Log("Player attempted to use resource without sufficent material");
        }
        
    }
    // Craftingtable setblocktext to 
    public void SetBlockText()
    {
        if (ACount == null)
        {
            Debug.Log("ACount is null!!!!");
        }
        ACount.text = "Grass:  " + HarvestBlock.blockA.ToString();
        BCount.text = "Stone:  " + HarvestBlock.blockB.ToString();
        CCount.text = "Snow:  " + HarvestBlock.blockC.ToString();
        // DCount.text = "Battery:  " + blockD.ToString();
    } // End SetBlockText
}


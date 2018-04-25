using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour {

    public Button btnIron;
    public Button btnGold;
    public Button btnElectric;
    public Button btnBattery;
    public Button btnUseBattery;

    public static int rIron;
    public static int rGold;
    public static int rElectric;
    public static int rBattery;

    public static int delim;

    CursorLockMode wantedMode;

    // public GameObject[] menu;
    public CanvasGroup canvasGroup;
    // public GameObject CraftPanel;
    // public 

    public Text Iron;
    public Text Gold;
    public Text Electric;
    public Text Battery;

    // Use this for initialization
    void Start () {
        delim = 0;
        // CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        Iron.text = "0";
        Gold.text = "0";
        Electric.text = "0";
        // Battery.text = "0";
        rIron = 0;
        rGold = 0;
        rElectric = 0;
        rBattery = 1;
        Battery.text = rBattery.ToString();
        // menu = GameObject.FindGameObjectsWithTag("CraftPanel");
        // These two should set the mouse properly at the start, don't know why I needed 2
        SetCursorState(delim);
        SetCursorState(delim);
        // listeners for buttons
        btnIron.onClick.AddListener(btnIronOnClick);
        btnGold.onClick.AddListener(btnGoldOnClick);
        btnElectric.onClick.AddListener(btnElectricOnClick);
        btnBattery.onClick.AddListener(btnBatteryOnClick);
        btnUseBattery.onClick.AddListener(btnUseBatteryOnClick);
    }
	
	// Update is called once per frame
	void Update () {    
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            delim = 1;        
            Debug.Log("keycode recognition works");
            SetCursorState(delim);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // FirstPersonController.Lock Curser == checked
            delim = 0;
            // GameObject.Find("CraftPanel").SetActive(false);
            Debug.Log("Closing menu");
            SetCursorState(delim);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            hpDrain.health += 9999999;
            Debug.Log("Godmode aquired, press key additional times for more health");
            //FirstPersonController.Lock Curser == unchecked
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            hpDrain.health = 100;
            Debug.Log("Deactivated Godmode or reset to normal health");
            //FirstPersonController.Lock Curser == unchecked
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
    /*
        public void CraftMenu(int bob)
        {
            Debug.Log("Start of CraftMenu"); // old craft menu before new script
            // CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

            if (bob == 1)
            {
                // canvasGroup.alpha = bob;
                // canvasGroup.alpha
                // menuToggle();
                Debug.Log("ITS ALIVE, ALIVE!!!!!");
                // yield return null;
                //StartCoroutine(appear(bob));
                SetCursorState(bob);
            }
            else
            {
                Debug.Log("Else it is dead jim.");
            }
            while (bob == 1)
            {
                // This is to check for player input and end while loop
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    // FirstPersonController.Lock Curser == checked
                    bob = 0;
                    // GameObject.Find("CraftPanel").SetActive(false);
                    Debug.Log("It's dead jim.");
                    CraftMenu(bob);
                    SetCursorState(bob);
                }
                // yield return null;
                // GameObject.Find("CraftPanel").SetActive(true);
                 SetCursorState(bob);
                hpDrain.health += .02;
            }
            Debug.Log("Craft table cycle complete.");
        }

        IEnumerator appear(int bob)
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            if (bob == 1)
            {
                canvasGroup.alpha = bob;
                while (canvasGroup.alpha >= 1)
                {
                    canvasGroup.alpha += Time.deltaTime / 2;
                    yield return null;
                }
            }
            else
            {
                canvasGroup.alpha = bob;
                while (canvasGroup.alpha <= 0)
                {
                    canvasGroup.alpha -= Time.deltaTime / 2;
                    yield return null;
                }
            }
            canvasGroup.interactable = false;
            yield return null;
        }
     */
    // Use this for initialization

    // Apply requested cursor state
    void SetCursorState(int mouse)
    {
        Cursor.lockState = wantedMode;
        if (mouse == 1)
        {
            Debug.Log("Mouse is free");
            //while (mouse == 1)
            //{
                wantedMode = CursorLockMode.None;
                Cursor.visible = true;
            //}
            
        }
        else
        {
            Debug.Log("Mouse is caged");
            //while (mouse != 1)
            //{
                wantedMode = CursorLockMode.Locked;
                // Hide cursor when locking
                Cursor.visible = (CursorLockMode.Locked != wantedMode);
            //}
                
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
        }
        else
        {
            Debug.Log("Gold cost is 5 stone ");
            Debug.Log("Player attempted to generate resource without sufficent material");
        }
        
    }
    void btnElectricOnClick()
    {
        if (HarvestBlock.blockC >= 3)
        {
            HarvestBlock.blockC = HarvestBlock.blockC - 2;
            rElectric++;
            Debug.Log("rElectric = " + rElectric);
            Electric.text = "Electric: " + rElectric.ToString();
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

}


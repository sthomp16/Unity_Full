using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpDrain : MonoBehaviour {

    public Text WarningText;
    public Text BatteryText;
    public Text LossText;

    public Image Full;
    public Image Half;
    public Image Low;

    public static double health;
    private int minecost = 1;
    
    private const double coef = 0.02;
   

    private void Start()
    {
        LossText.text = "";
        health = 100;
    }

    // Update is called once per frame
    void Update () {
        // Debug.Log("Subtracting health");
        health -= coef; // + Time.deltaTime;
        // drain battery if player clicks mouse
        if (Input.GetMouseButtonDown(0) && CraftingTable.delim != 1)
        {
            //Debug.Log("Battery drained via click");
            health = health - minecost;
            // Debug.Log("Battery drained: " + minecost);
        }
        if (health < 0)
        {
            health = 0;
        }
            // Debug.Log("Before display battery");
        BatteryText.text = "Battery Left:  " + health.ToString("0") + "%";
        // Debug.Log("After display battery");
        SetText(health);
    }

    private void SetText(double health)
    {
        if (health > 55)
        {
            Full.enabled = true;
            WarningText.text = "Sufficent charge";
        }
        else if (health >= 45)
        {
            Full.enabled = false;
            Half.enabled = true;
            WarningText.text = "Warning: Half battery";
        }
        else if (health >= 10)
        {
            // Full.enabled = false;
            Half.enabled = false;
            Low.enabled= true;
            WarningText.text = "Warning: Low battery";
        }
        else if (health > 0)
        {
            BatteryText.text = "Battery is near dead" + health.ToString("0") + "%";
            // display black screan
            // display "You have lost power."
            
        }
        else
        {
            BatteryText.text = "Battery is dead" + health.ToString("0") + "%";
            Debug.Log("How did you get here?");
            LossText.text = "You have lost power!";
        }
    }
}

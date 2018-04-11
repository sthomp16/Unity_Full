using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpDrain : MonoBehaviour {

    public Text WarningText;
    public Text BatteryText;
    public Text LossText;
    public double health = 100;
    private const double coef = 0.02;

    private void Start()
    {
        LossText.text = "";
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("Subtracting health");
        health -= coef; // + Time.deltaTime;
        Debug.Log("Before display battery");
        BatteryText.text = "Battery Left:  " + health.ToString("0") + "%";
        // Debug.Log("After display battery");
        SetText();
    }

    void SetText()
    {
        if (health > 55)
        {
            WarningText.text = "Sufficent charge";
        }
        if (health <= 45 && health <= 55)
        {
            WarningText.text = "Warning: Half battery";
        }
        if (health <= 26 && health != 0)
        {
            WarningText.text = "Warning: Low battery";
        }
        if (health == 0)
        {
            BatteryText.text = "Battery is dead" + health.ToString("0") + "%";
            // display black screan
            // display "You have lost power."
            LossText.text = "You have lost power!";
        }
    }
}

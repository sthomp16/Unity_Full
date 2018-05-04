using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menupop : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(appear());
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(appear());
        }
    }
    /*
    public void menuToggle()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(appear());
        }
        
    }
    */

    IEnumerator appear()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        // bill = CameraClearFlags.default;
        if (CraftingTable.delim >= 1)
        {
            canvasGroup.alpha = CraftingTable.delim;
            canvasGroup.interactable = true;
            yield return null;

        }
        else if (CraftingTable.delim <= 0)
        {
            canvasGroup.alpha = CraftingTable.delim;
            canvasGroup.interactable = false;
            yield return null;
        }
        // canvasGroup.interactable = false;
        yield return null;
    }
}

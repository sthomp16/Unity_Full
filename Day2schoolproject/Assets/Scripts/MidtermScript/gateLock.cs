using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gateLock : MonoBehaviour {

    public Animator animator;

    private int cells;
    private int count;


    void OnTriggerEnter(Collider other)
    {
        if (Collector.gateKeeper >= 1)
            animator.SetBool("isOpen", true);
        else
            animator.SetBool("isOpen", false);
            Debug.Log("Not enough power");
    }

    void OnTriggerExit(Collider other)
    {
        animator.SetBool("isOpen", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateLock2 : MonoBehaviour {

    public Animator animator;

    private int cells;
    private int count;


    void OnTriggerEnter(Collider other)
    {
        if (Collector.gateKeeper >= 2)
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

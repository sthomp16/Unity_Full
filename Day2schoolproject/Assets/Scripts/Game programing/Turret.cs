using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject rotatable;
    public GameObject spawnPt;
    public GameObject cannonball;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(shootCannonball());
    }


    // Update is called once per frame
    void Update()
    {
        float a = 70 * Time.time;
        rotatable.transform.localRotation = Quaternion.Euler(0, a, 0);
    }

    // a coroutine to shoot a cannonball automaticly
    IEnumerator shootCannonball()
    {
        while (true)
        {
            // 
            GameObject go = Instantiate(cannonball);
            go.transform.localPosition = spawnPt.transform.position;
            go.transform.localRotation = spawnPt.transform.rotation;
            go.GetComponent<Rigidbody>().velocity = 2 * spawnPt.transform.forward;
            Destroy(go, 5f);

            yield return new WaitForSeconds(3f);
        }
    }
}
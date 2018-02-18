using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenStart : MonoBehaviour
{

    public GameObject parent;
    // public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;


    private float rand(float min, float max)
    {
        return Random.Range(min, max);
    }

    private void gen(GameObject prefab, string name,
                    float px, float py, float pz,
                    float rx, float ry, float rz,
                    float sx, float sy, float sz)
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(px, py, pz);
        go.transform.localRotation = Quaternion.Euler(rx, ry, rz);
        go.transform.localScale = new Vector3(sx, sy, sz);
        go.transform.parent = parent.transform;
        go.name = name;
    }

    void Start()
    {
        // gen(prefab0, "Ez Car", -67, -4, 18, 0, 180, 0, 1, 1, 1);
        gen(prefab1, "Pod", 58, -4, 16, 84, 51, -62, 1, 1, 1);
        gen(prefab2, "Wall Gate", 65, -15, 36, 0, 0, 0, 1, 1, 1);
        gen(prefab2, "Wall", 51, -7, 10, 0, 90, 0, 20, 2, 1);
    }
}

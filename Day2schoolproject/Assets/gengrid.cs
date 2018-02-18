using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gengridA : MonoBehaviour {

    public GameObject parent;
    public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;

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
        gen(prefab0, "Buldblock 1", -16, 5, -29, 0, 90, 0, 1, 1, 1);
        gen(prefab1, "Gen Enviro (1)", -37, 5, 9, 0, 90, 0, 20, 2, 1);
        gen(prefab2, "Gen Enviro (2)", -30, 5, 9, 0, 90, 0, 20, 2, 1);


    }
}

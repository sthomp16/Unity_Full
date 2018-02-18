using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenWorldWalls : MonoBehaviour {

    public GameObject parent;
    public GameObject prefab0;
    public GameObject prefab1;


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
        gen(prefab0, "North Wall", 0, 2, 49, 0, 0, 0, 100, 4, 1);
        gen(prefab0, "South Wall", 0, 2, -49, 0, 0, 0, 100, 4, 1);
        gen(prefab1, "East Wall", 49, 2, 0, 0, 90, 0, 100, 4, 1);
        gen(prefab1, "West wall", -49, 2, 0, 0, 90, 0, 100, 4, 1);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S07c_main : MonoBehaviour
{

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
        gen(prefab0, "P0a", 1, 2, 3, 0, 0, 0, 1, 1, 1);
        gen(prefab0, "P0b", -1, 1, 3, 0, 90, 0, 1, 1, 1);
        gen(prefab1, "P1", rand(2, 3), 0, 4, -1, 0, 90, 0, 2, 1);
        gen(prefab2, "P3", 1, 5, 0, 0, 0, 0, 0.3f, 0.3f, 0.3f);
    }

}
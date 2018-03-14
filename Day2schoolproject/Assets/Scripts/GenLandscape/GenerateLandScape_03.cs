using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLandScape_03 : MonoBehaviour {

    // Use this for initialization
    public int worldSizeW = 64; // x-direction
    public int worldSizeH = 64; // z direction
    public int heightScale = 20; // x-direction
    public float detailScale = 25.0f; // z direction
    public GameObject MC_GrassBlock;

    void Start()
    {
        // int y = 0;
        // Random.InitState(System.DateTime.Now.Millisecond
        for (int z = 0; z < worldSizeH; z++)
        {
            for (int x = 0; x < worldSizeW; x++)
            {
                int y = (int)Random.Range(0,10);
                Vector3 pos = new Vector3(x, y, z);
                Instantiate(MC_GrassBlock, pos, Quaternion.identity);
            }
        }

    }
}

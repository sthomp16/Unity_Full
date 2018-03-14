using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLandscape_05 : MonoBehaviour {

    // Use this for initialization
    public int worldSizeW = 64; // x-direction
    public int worldSizeH = 64; // z direction
    public int heightScale = 20; // x-direction
    public float detailScale = 25.0f; // z direction
    
    public GameObject MC_GrassBlock;
    public GameObject MC_SnowBlock;
    void Start()
    {
        int ySnow = (int)(0.7f * heightScale);
        Random.InitState(System.DateTime.Now.Millisecond);
        float ofsX = Random.Range(0, 10);
        float ofsZ = Random.Range(0, 10);

        for (int z = 0; z < worldSizeH; z++)
        {
            for (int x = 0; x < worldSizeW; x++)
            {
                float fx = ofsX + x / detailScale;
                float fz = ofsZ + z / detailScale;
                int y = (int)(Mathf.PerlinNoise(fx,fz)* heightScale);
                Vector3 pos = new Vector3(x, y, z);
                if (y >= ySnow)
                {
                    Instantiate(MC_SnowBlock, pos, Quaternion.identity);
                }
                
                else {
                    Instantiate(MC_GrassBlock, pos, Quaternion.identity);
                }
            }
        }

    }
}

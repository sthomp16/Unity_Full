﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLandscape_11 : MonoBehaviour {

  public int worldSizeW = 64;  // x-direction
  public int worldSizeH = 64;  // z-direction
  public float heightScale = 20;
  public float detailScale = 25.0f;

  public GameObject prefabSand;
  public GameObject prefabGrass;
  public GameObject prefabSnow;

  void Start() {
    int yBottom = -5; // the bottom offset
    int yGrass = (int)(0.3f * heightScale); // for y = yGrass, yGrass+1, ..., ySnow-1
    int ySnow = (int)(0.7f * heightScale); // for y = ySnow, ySnow+1, ...
    //
    Random.InitState(System.DateTime.Now.Millisecond);
    float ofsX = Random.Range(0, 10);
    float ofsZ = Random.Range(0, 10);
    for(int z = 0; z < worldSizeH; z++) {
      for(int x = 0; x < worldSizeW; x++) {
        float fx = ofsX + x / detailScale;
        float fz = ofsZ + z / detailScale;
        // calculate the height of the mountain-surface
        int h = (int)(Mathf.PerlinNoise(fx, fz) * heightScale);
        // fill the vertical column with blocks (from bottom to mountain-surface)
        for(int y = yBottom; y <= h; y++) {
          Vector3 pos = new Vector3(x, y, z);
          if(y >= ySnow) {
            Instantiate(prefabSnow, pos, Quaternion.identity);
          } else if(y >= yGrass) {
            Instantiate(prefabGrass, pos, Quaternion.identity);
          } else {
            Instantiate(prefabSand, pos, Quaternion.identity);
          }
        }
      }
    }
  }


}

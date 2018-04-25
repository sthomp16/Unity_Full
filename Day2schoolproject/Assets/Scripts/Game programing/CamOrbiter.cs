using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOrbiter : MonoBehaviour {

  public int centerX = 32;
  public int centerZ = 32;
  public int heightY = 50;
  public int radius = 50;
  public float speed = 1.0f;

  private Camera cam;
  private Vector3 lookAt;

  void Start() {
    cam = GameObject.FindObjectOfType<Camera>();
    lookAt = new Vector3(centerX, 0.2f * heightY, centerZ);
  }

  void Update() {
    float t = 0.3f * Time.time * speed;
    float x = centerX + radius * Mathf.Cos(t);
    float z = centerZ + radius * Mathf.Sin(t);
    cam.transform.position = new Vector3(x, heightY, z);
    cam.transform.LookAt(lookAt);
  }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03f_main : MonoBehaviour {

  // Earth’s rotation: Earth spins on its axis, one counterclockwise rotation every 24 hours.
  // Earth’s revolution: Earth goes around the sun, one counterclockwise revolution every 365 days.

  // following numbers are for looks-and-feels, have NO real meaning!
  private float radius = 3.4f;
  private float rotSpeed = 0.7f;
  private float revSpeed = 174f;

  void Update() {
    float t = Time.time;
    float posX = radius * Mathf.Cos(rotSpeed * t);
    float posZ = radius * Mathf.Sin(rotSpeed * t);
    float posY = 0;
    gameObject.transform.position = new Vector3(posX, posY, posZ);
    float rotY = revSpeed * t;
    gameObject.transform.localRotation = Quaternion.Euler(0, rotY, 0);
  }
}

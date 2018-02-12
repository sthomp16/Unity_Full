using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S06a_main : MonoBehaviour {

  public Text healthTxt;
  public RectTransform healthBar;

  private float maxHeath = 750;
  private float curHealth = 0;

  private void updateUi() {
    float fraction = curHealth / maxHeath;
    string info = string.Format("{0:0}\n{1}%", curHealth, (int)(100 * fraction));
    //
    healthTxt.text = info;
    healthBar.localScale = new Vector3(fraction, 1, 1);
  }

  void Start() {
    curHealth = maxHeath;
    updateUi();
  }

  void Update() {
    curHealth = (1 + Mathf.Cos(0.43f * Time.time)) / 2 * maxHeath;
    updateUi();
  }

}

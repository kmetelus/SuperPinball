using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {
  private float t = 0f;

  void Update () {
    t += Time.deltaTime;
    if (t >= 2.0f) {
      float x = this.transform.position.x;
      float y = this.transform.position.y;
      float z = this.transform.position.z;
      this.transform.position = new Vector3 (x, y, z - 0.5f);
      t = 0.0f;
    }
  }
}

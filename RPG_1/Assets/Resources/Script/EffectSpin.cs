using UnityEngine;
using System.Collections;

public class EffectSpin : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 1000f);
	}
}

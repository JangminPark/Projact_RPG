using UnityEngine;
using System.Collections;

public class OverlapAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Collider>().isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Respawn")
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            Debug.Log("벽에 부딪침");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Respawn")
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}

using UnityEngine;
using System.Collections;

public class MobEvent : MonoBehaviour {

    public GameObject punch;

    public void Oncollider()
    {
        punch.GetComponent<Collider>().enabled = true;
    }

    public void Offcollider()
    {
        punch.GetComponent<Collider>().enabled = false;
    }
}

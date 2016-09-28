using UnityEngine;
using System.Collections;

public class MobStopMove : MonoBehaviour {

    public void MoveStop()
    {
        MobAction mobAction = transform.parent.GetComponent<MobAction>();
        mobAction.movestop = false;
    }

    public void ColliderOn()
    {
        gameObject.GetComponentInChildren<SphereCollider>().enabled = true;
    }

    public void ColliderOff()
    {
        gameObject.GetComponentInChildren<SphereCollider>().enabled = false;
    }
}

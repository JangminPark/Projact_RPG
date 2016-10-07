using UnityEngine;
using System.Collections;

public class PlayerStopMove : MonoBehaviour {

    public PlayerAction playeraction;

    public void MoveStop()
    {
        playeraction.state = PLAYERSTATE.IDLE;
        playeraction.movestop = false;
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

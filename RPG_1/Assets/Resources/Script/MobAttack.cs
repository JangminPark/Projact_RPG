using UnityEngine;
using System.Collections;

public class MobAttack : MonoBehaviour {

    public PlayerAction playeraction;
    public MobAction mobaction;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playeraction.Hp -= mobaction.Damage;

            if (playeraction.Hp <= 0)
            {
                playeraction.state = PLAYERSTATE.DIE;
                playeraction.ani.SetTrigger("die");
            }

            Debug.Log("플레이어를 공격함!!!!");
        }
    }
}

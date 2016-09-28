using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public PlayerAction playeraction;
    public MobAction mobaction;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "mob")
        {
            mobaction.Hp -= playeraction.Damage;

            if (mobaction.Hp <= 0)
            {
                mobaction.state = MOBSTATE.DIE;
                mobaction.ani.SetTrigger("die");
            }

            Debug.Log("몬스터를 공격함!!!!");
        }
    }
}

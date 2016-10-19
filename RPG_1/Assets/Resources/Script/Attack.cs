using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Mob")
        {
            GameObject player = GameObject.Find("player");

            col.gameObject.GetComponent<MobAction>().hp -= player.GetComponent<PlayerAction>().Damage;

            Debug.Log("몬스터 HP " + col.gameObject.GetComponent<MobAction>().hp + " 를 공격( " + player.GetComponent<PlayerAction>().Damage + " ) 함!! ") ;
        }
    }
}

using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Mob")
        {
            GameObject player = GameObject.Find("player");
            GameObject gamemanager = GameObject.Find("GameManager");

            col.gameObject.GetComponent<MobAction>().hp -= player.GetComponent<PlayerAction>().Damage;

            Debug.Log("몬스터 HP " + col.gameObject.GetComponent<MobAction>().hp + " 를 공격( " + player.GetComponent<PlayerAction>().Damage + " ) 함!! ") ;

            if (col.gameObject.GetComponent<MobAction>().hp <= 0)
            {
                col.gameObject.GetComponent<MobAction>().ani.SetTrigger("die");
                col.gameObject.GetComponent<MobAction>().state = MOBSTATE.DIE;
                gamemanager.GetComponent<GameManager>().mobrecreate++;
                gamemanager.GetComponent<GameManager>().bossCount++;
            }
        }
    }
}

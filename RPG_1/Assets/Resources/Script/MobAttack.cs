using UnityEngine;
using System.Collections;

public class MobAttack : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerAction>().Hp -= gameObject.GetComponentInParent<MobAction>().damage;

            Debug.Log("플레이어의 HP가 " + col.gameObject.GetComponent<PlayerAction>().Hp + "남았습니다");
        }
    }
}

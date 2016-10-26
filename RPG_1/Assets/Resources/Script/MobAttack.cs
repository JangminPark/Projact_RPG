using UnityEngine;
using System.Collections;

public class MobAttack : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerAction>().Hp -= gameObject.GetComponentInParent<MobAction>().damage;

            Debug.Log("" + col.gameObject.GetComponent<PlayerAction>().Hp + "가 남았습니다");
        }
    }
}

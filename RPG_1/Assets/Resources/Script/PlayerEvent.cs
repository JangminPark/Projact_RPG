using UnityEngine;
using System.Collections;

public class PlayerEvent : MonoBehaviour {

    public GameObject Player;

	public void LastAttack()
    {
        GameObject wave = (GameObject)Resources.Load("Prefab/Effect/Shockwave");
        if (wave != null)
        {
            Instantiate(wave, Player.transform.position + Vector3.up * 1f + Player.transform.forward*5f, Quaternion.LookRotation(Player.transform.forward));
        }
    }
}

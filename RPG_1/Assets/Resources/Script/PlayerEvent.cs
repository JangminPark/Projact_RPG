using UnityEngine;
using System.Collections;

public class PlayerEvent : MonoBehaviour {

    public GameObject player;
    public GameObject sword;

	public IEnumerator LastAttack()
    {
        GameObject obj = (GameObject)Resources.Load("Prefab/Effect/Shockwave");
        if (obj != null)
        {
            GameObject wave = (GameObject)Instantiate(obj, player.transform.position + Vector3.up * 1f + player.transform.forward*8f, Quaternion.LookRotation(player.transform.forward));
            yield return new WaitForSeconds(1f);
            Destroy(wave);
        }
    }

    public void LastDamage()
    {
        player.GetComponent<PlayerAction>().state = PLAYERSTATE.LAST_ATTACK;
    }

    public void Oncollider()
    {
        sword.GetComponent<Collider>().enabled = true;
    }

    public void Offcollider()
    {
        sword.GetComponent<Collider>().enabled = false;
    }
}

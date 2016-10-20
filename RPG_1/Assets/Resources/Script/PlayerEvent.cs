using UnityEngine;
using System.Collections;

public class PlayerEvent : MonoBehaviour {

    public GameObject player;
    public GameObject sword;
    public GameObject shield;
    public Camera mainCamera;
    public GameObject uicamera;

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

    public IEnumerator SkillStart()
    {
        mainCamera.GetComponent<CameraController>().SkillOn = true;
        uicamera.SetActive(false);
        GameObject obj=(GameObject)Resources.Load("Prefab/Effect/Heal");
        if (obj != null)
        {
            GameObject powerUP = (GameObject)Instantiate(obj, shield.transform.position + Vector3.up * 1.5f + player.transform.forward * 1f, Quaternion.LookRotation(shield.transform.forward));
            yield return new WaitForSeconds(1f);
            Destroy(powerUP);
        }
    }

    public IEnumerator DashOn()
    {
        player.GetComponent<PlayerAction>().state = PLAYERSTATE.SKILL;
        player.GetComponent<PlayerAction>().Dashcheck = true;
        shield.GetComponent<Collider>().enabled = true;
        mainCamera.GetComponent<CameraController>().SkillOn = false;

        GameObject obj = (GameObject)Resources.Load("Prefab/Effect/RocketFire");
        if (obj != null)
        {
            GameObject roketFire = (GameObject)Instantiate(obj, player.transform.position + Vector3.up * 1.5f + player.transform.forward * -10f, Quaternion.LookRotation(player.transform.forward));
            roketFire.transform.parent = player.transform;      //생성한 로켓파이어를 플레이어의 자식으로 놓는다
            yield return new WaitForSeconds(0.8f);
            Destroy(roketFire);
        }
    }

    public void DashOff()
    {
        player.GetComponent<PlayerAction>().Dashcheck = false;
        shield.GetComponent<Collider>().enabled = false;
        uicamera.SetActive(true);
    }
}

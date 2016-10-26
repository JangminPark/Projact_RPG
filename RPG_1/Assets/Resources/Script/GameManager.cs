using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public List<GameObject> createMobs = new List<GameObject>();
    public List<GameObject> respawns = new List<GameObject>();

    public GameObject player;
    public GameObject mob;

    public UIAnchor mobHpUI;

    public UISprite playerHpBar;
    public UISprite mobHpBar;

    public UILabel mobName;

    public int wave = 0;
    public int mobCount = 0;

    public float MobHP = 0f;
    public int MobAttack = 0;
    public string MobName;

    void Start()
    {
        StartCoroutine(CreateMob());
    }

    void Update()
    {
        playerHpBar.fillAmount = player.GetComponent<PlayerAction>().Hp * 0.01f;
    }
    IEnumerator CreateMob()
    {
        mobCount = 10;
        GameObject resmob = (GameObject)Resources.Load("Prefab/Character/Monster");
        if (resmob == null)
        {
            Debug.Log("몬스터를 불러올 수 없습니다");
            yield return null;
        }

        for (int i = 0; i < mobCount; i++)
        {
            yield return new WaitForSeconds(1.5f);
            mob = Instantiate(resmob);
            int resCount = Random.Range(0, respawns.Count);
            mob.transform.position = respawns[resCount].transform.position;
            mob.GetComponent<MobAction>().SetStat(MobHP, MobAttack, MobName);
            mobName.text = "" + MobName;

            createMobs.Add(mob);
        }
    }
}

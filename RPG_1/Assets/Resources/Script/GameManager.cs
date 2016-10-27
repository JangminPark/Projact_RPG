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

    public UILabel playerHpLabel;
    public UILabel mobName;
    public UILabel bossCountLabel;

    public int wave = 0;
    public int mobCount = 0;
    public int bossCount = 0;
    public int mobrecreate = 0;

    public float MobHP = 0f;
    public int MobAttack = 0;
    public string MobName;

    void Start()
    {
        StartCoroutine(CreateMob());
    }

    void Update()
    {
        playerHpBar.fillAmount = player.GetComponent<PlayerAction>().Hp * 0.01f;        //플레이어 체력바
        playerHpLabel.text = (100f*playerHpBar.fillAmount).ToString("n0")+"%";                     //플레이어 체력퍼센트
        bossCountLabel.text = bossCount + "/10";                                        //보스 등장 카운트


        //몬스터 10마리가 죽으면 초기화 후에 다시 생성
        if (mobrecreate >= 10)
        {
            mobCount = 0;
            mobrecreate = 0;
            StartCoroutine(CreateMob());
        }
    }
    IEnumerator CreateMob()
    {
        //몬스터 10마리가 될때까지 생성
        while(mobCount < 10)
        {
            GameObject resmob = (GameObject)Resources.Load("Prefab/Character/Monster");
            if (resmob == null)
            {
                Debug.Log("몬스터를 불러올 수 없습니다");
                yield return null;
            }
            yield return new WaitForSeconds(1.5f);
            mob = Instantiate(resmob);
            int resCount = Random.Range(0, respawns.Count);
            mob.transform.position = respawns[resCount].transform.position;
            mob.GetComponent<MobAction>().SetStat(MobHP, MobAttack, MobName);
            mobName.text = "" + MobName;

            createMobs.Add(mob);
            mobCount++;
        }
    }
}

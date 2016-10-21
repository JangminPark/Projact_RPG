using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> createMobs = new List<GameObject>();
    public List<GameObject> respawns = new List<GameObject>();

    public int wave = 0;
    public int mobCount = 10;

    public float baseMobHP = 0f;
    public float baseMobAttack = 0f;

    void Start()
    {
        StartCoroutine(CreateMob());
    }
    IEnumerator CreateMob()
    {
        int resCount = Random.Range(0, respawns.Count);
        GameObject posObj = respawns[resCount];

        GameObject resmob = (GameObject)Resources.Load("Prefab/Character/Monster");
        if (resmob == null)
        {
            Debug.Log("몬스터를 불러올 수 없습니다");
            yield return null;
        }
        GameObject mob = Instantiate(resmob);
        mob.transform.position = respawns[resCount].transform.position;
    }
}

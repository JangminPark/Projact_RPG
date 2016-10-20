using UnityEngine;
using System.Collections;

public class UIAction : MonoBehaviour {

    public GameObject player;
    public GameObject mob;

    public UISprite playerHP;
    public UISprite mobHP;

    void Start()
    {

    }

    void Update()
    {
        playerHP.fillAmount = player.GetComponent<PlayerAction>().Hp * 0.01f;       //UI 플레이어 체력
        mobHP.fillAmount = mob.GetComponent<MobAction>().hp * 0.01f;                //UI 몬스터 체력
    }
}

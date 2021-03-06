﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MOBSTATE
{
    IDLE,
    MOVE,
    ATTACK,
    DAMAGE,
    DIE,
}

public class MobAction : MonoBehaviour {

    public MOBSTATE state = MOBSTATE.IDLE;

    private GameObject player;
    public GameObject overlap;

    public Animator ani;

    public string name = "오크전사";
    public float hp = 100;
    public int damage = 5;

    public bool movestop = false;

	void Start () {
        state = MOBSTATE.IDLE;
        player = GameObject.Find("player");
        ani = transform.GetComponentInChildren<Animator>();

    }
	
	void Update () {

        switch (state)
        {
            case MOBSTATE.IDLE:
                //플레이어와 몬스터 사이의 거리가 10보다 작으면 실행
                if (Vector3.Distance(player.transform.position, transform.position) < 100f)
                {
                    state = MOBSTATE.MOVE;
                }
                break;

            case MOBSTATE.MOVE:
                ProcessMove();
                break;

            case MOBSTATE.ATTACK:
                break;

            case MOBSTATE.DAMAGE:
                break;

            case MOBSTATE.DIE:
                ProcessDie();
                break;
        }
	}

    //이동시키는 함수
    void ProcessMove()
    {
        if (movestop == false)
        {
            Vector3 height = player.transform.position;
            height.y = 0f;
            ani.SetBool("run", true);
            
            float speed = 5f;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.LookAt(height);       //플레이어를 바라보게한다

            if (Vector3.Distance(player.transform.position, transform.position) < 3f)
            {
                state = MOBSTATE.ATTACK;
                ProcessAttack();
            }
            if (hp <= 0)
            {
                state = MOBSTATE.DIE;
            }
        }
    }

    void ProcessAttack()
    {
        ani.SetTrigger("attack");
        movestop = true;

        if (Vector3.Distance(player.transform.position, transform.position) > 2f)
        {
            state = MOBSTATE.MOVE;
            movestop = false;
            CancelInvoke("ProcessAttack");
            ani.ResetTrigger("attack");
            return;
        }

        Invoke("ProcessAttack", 2f);        //몬스터 다음공격 딜레이
    }

    void ProcessDie()
    {
        movestop = true;
        overlap.GetComponent<Collider>().enabled = false;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }


    public void SetStat(float statHp,int statdamage,string statname)
    {
        statHp = hp;
        statdamage = damage;
        statname = name;
    }
}

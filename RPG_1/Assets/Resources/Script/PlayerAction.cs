using UnityEngine;
using System.Collections;

public enum PLAYERSTATE
{
    IDLE,
    RUN,
    ATTACK,
    LAST_ATTACK,
    SKILL,
    CYCYLON,
    DIE,
}

public class PlayerAction : MonoBehaviour
{

    public PLAYERSTATE state = PLAYERSTATE.IDLE;

    public GameObject mob;
    public Animator ani;

    public int Hp = 100;
    public int Damage = 0;

    public bool Dashcheck = false;

    void Start()
    {
        ani = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //스킬 사용시 앞으로 나가게한다
        if (Dashcheck == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 30f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Skill();
        }

        switch (state)
        {
            case PLAYERSTATE.IDLE:
                break;

            case PLAYERSTATE.RUN:
                break;

            case PLAYERSTATE.ATTACK:
                break;

            case PLAYERSTATE.LAST_ATTACK:
                Last_Attack();
                break;

            case PLAYERSTATE.SKILL:
                break;

            case PLAYERSTATE.CYCYLON:
                break;

            case PLAYERSTATE.DIE:
                break;
        }
    }

    public void Attack()
    {
        state = PLAYERSTATE.ATTACK;
        Damage = 20;
        ani.SetTrigger("attack");
    }

    public void Last_Attack()
    {
        state = PLAYERSTATE.LAST_ATTACK;
        Damage = 40;
    }

    public void Skill()
    {
        state = PLAYERSTATE.SKILL;
        ani.SetTrigger("defend");
        Damage = 60;
    }

    public void Cyclons()
    {
        state = PLAYERSTATE.CYCYLON;
        ani.SetTrigger("spin");
        Damage = 20;
    }
}
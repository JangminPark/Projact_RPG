using UnityEngine;
using System.Collections;

public enum PLAYERSTATE
{
    IDLE,
    RUN,
    ATTACK,
    LAST_ATTACK,
    SKILL,
    DIE,
}

public class PlayerAction : MonoBehaviour
{

    public PLAYERSTATE state = PLAYERSTATE.IDLE;

    public GameObject mob;
    public Animator ani;

    public float speed = 10;
    public int Hp = 100;
    public int Damage = 0;

    public float defendValue = 0;

    void Start()
    {
        ani = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
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
                Attack();
                break;

            case PLAYERSTATE.LAST_ATTACK:
                Last_Attack();
                break;

            case PLAYERSTATE.SKILL:
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
        transform.Translate(1f * speed * Time.deltaTime, 0, 0);

        if (state == PLAYERSTATE.SKILL && defendValue < 3)
        {
            defendValue++;
            transform.Translate(defendValue * speed * Time.deltaTime, 0, 0);

            if (defendValue >= 3)
            {
                defendValue = 0;
                state = PLAYERSTATE.IDLE;
            }
        }
    }
}
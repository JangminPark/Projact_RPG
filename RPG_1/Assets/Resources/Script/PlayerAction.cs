using UnityEngine;
using System.Collections;

public enum PLAYERSTATE
{
    IDLE,
    RUN,
    ATTACK,
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
    public int Damage = 20;
    public bool movestop = false;

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
        ani.SetTrigger("attack");
        movestop = true;
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
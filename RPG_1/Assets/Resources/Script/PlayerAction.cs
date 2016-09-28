using UnityEngine;
using System.Collections;

public enum PLAYERSTATE
{
    IDLE,
    RUN,
    DIE,
}

public class PlayerAction : MonoBehaviour
{

    public PLAYERSTATE state = PLAYERSTATE.IDLE;

    public Animator ani;

    public float speed = 10;
    public int Hp = 100;
    public int Damage = 20;
    public bool movestop = false;

    void Start()
    {
        ani = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //===================공격============================
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
        //==================================================

        //=======================방어==========================
        if (Input.GetKeyDown(KeyCode.S))
        {
            Defend();
        }
        //====================================================

        //=======================이동=========================

        if (movestop == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                state = PLAYERSTATE.RUN;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(Vector3.back);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                state = PLAYERSTATE.RUN;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                state = PLAYERSTATE.RUN;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(Vector3.left);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                state = PLAYERSTATE.RUN;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(Vector3.right);
            }
        }
        //===================================================

        switch (state)
        {
            case PLAYERSTATE.IDLE:
                ani.SetBool("run", false);
                break;

            case PLAYERSTATE.RUN:
                ani.SetBool("run", true);
                break;

            case PLAYERSTATE.DIE:
                break;
        }
    }

    public void Attack()
    {
        ani.SetTrigger("attack");
        movestop = true;
    }

    public void Defend()
    {
        ani.SetTrigger("defend");
    }
}

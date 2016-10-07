using UnityEngine;
using System.Collections;

public enum PLAYERSTATE
{
    IDLE,
    RUN,
    DIE,
    Dfend
}

public class PlayerAction : MonoBehaviour
{

    public PLAYERSTATE state = PLAYERSTATE.IDLE;

    public Animator ani;

    public float speed = 10;
    public int Hp = 100;
    public int Damage = 20;
    public bool movestop = false;

    private Rigidbody PlayerRigidbody;

    public float defendValue = 0;

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

            if (Input.GetKey(KeyCode.S))
            {
                state = PLAYERSTATE.Dfend;
                transform.Translate(1f * speed * Time.deltaTime, 0, 0);
            }
            if (state == PLAYERSTATE.Dfend && defendValue < 3)
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
                movestop = true;
                break;
            case PLAYERSTATE.Dfend:
                ani.SetTrigger("defend");
                break;
        }
    }

    public void Attack()
    {
        ani.SetTrigger("attack");
        movestop = true;
    }
}
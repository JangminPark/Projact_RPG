using UnityEngine;
using System.Collections;

public enum MOBSTATE
{
    IDLE,
    MOVE,
    ATTACK,
    DAMAGE,
    DIE,
}

public class MobAction : MonoBehaviour {

    public GameObject player;
    public Animator ani;
    public MOBSTATE state = MOBSTATE.IDLE;

    public int Hp = 100;
    public int Damage = 5;

    public bool movestop = false;

	void Start () {
        state = MOBSTATE.MOVE;

        ani = transform.GetComponentInChildren<Animator>();
	}
	
	void Update () {
        switch (state)
        {
            case MOBSTATE.MOVE:
                ProcessMove();
                break;

            case MOBSTATE.ATTACK:
                ProcessAttack();
                break;

            case MOBSTATE.DAMAGE:
                ProcessDamage();
                break;

            case MOBSTATE.DIE:
                break;
        }
	}

    //플레이어를 보고 따라가게 만든다
    void ProcessMove()
    {
        if (movestop == false)
        {
            Vector3 height = player.transform.position;
            height.y = 0f;
            ani.SetBool("run", true);
            float speed = 5f;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.LookAt(height);
        }
    }

    void ProcessAttack()
    {
        ani.SetTrigger("attack");
        movestop = true;
    }

    void ProcessDamage()
    {

    }

    //플레이어와 부딪쳤을때  행동
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            state = MOBSTATE.ATTACK;
        }
    }

    //콜리더 밖으로 나갓을때
    void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            state = MOBSTATE.MOVE;
        }
    }
}

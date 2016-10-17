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
        state = MOBSTATE.IDLE;

        ani = transform.GetComponentInChildren<Animator>();
	}
	
	void Update () {
        switch (state)
        {
            case MOBSTATE.IDLE:
                //플레이어와 몬스터 사이의 거리가 10보다 작으면 실행
                if (Vector3.Distance(player.transform.position, transform.position) < 10f)
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
            
            float speed = 3f;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.LookAt(height);       //플레이어를 바라보게한다

            if (Vector3.Distance(player.transform.position, transform.position) < 3f)
            {
                state = MOBSTATE.ATTACK;
                Attack();
            }
        }
    }

    void Attack()
    {
        ani.SetTrigger("attack");
        movestop = true;

        if (Vector3.Distance(player.transform.position, transform.position) > 2f)
        {
            state = MOBSTATE.MOVE;
            movestop = false;
            CancelInvoke("Attack");
            ani.ResetTrigger("attack");
            return;
        }

        Invoke("Attack", 2f);
    }


    void Gomove()
    {
        state = MOBSTATE.MOVE;
    }

    //플레이어와 부딪쳤을때  행동
    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.transform.tag == "Player")
    //    {
    //        state = MOBSTATE.ATTACK;
    //        ani.SetTrigger("attack");
    //        movestop = true;
    //    }
    //}

    //콜리더 밖으로 나갓을때
    //void OnTriggerExit(Collider col)
    //{
    //    if (col.transform.tag == "Player")
    //    {
    //        state = MOBSTATE.IDLE;
    //    }
    //}
}

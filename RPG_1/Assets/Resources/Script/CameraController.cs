using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    public bool SkillOn = false;
    public float zoom;
    public float timer;

    [HideInInspector]
    public float skillTime = 0f;

	void Start () {
        zoom = GetComponent<Camera>().orthographicSize = 10f;
        transform.rotation = Quaternion.Euler(10f, 0f, 0f);
        offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
        if(!SkillOn)
        {
            transform.position = player.transform.position + offset;
            zoom = GetComponent<Camera>().orthographicSize = 10f;
            transform.rotation = Quaternion.Euler(10f, 0f, 0f);
        }
        else
        {
            //zoom = GetComponent<Camera>().orthographicSize = 3f;
            //transform.rotation = Quaternion.Euler(15f, 0f, 0f);
            StartCoroutine(Zoomin(skillTime));
        }


        //timer += Time.deltaTime;
        //transform.position = player.transform.position + offset;
        //zoom = GetComponent<Camera>().orthographicSize = 10f;
        //transform.rotation = Quaternion.Euler(10f, 0f, 0f);

        //if (SkillOn == true)
        //{
        //    zoom = GetComponent<Camera>().orthographicSize = 3f;
        //    transform.rotation = Quaternion.Euler(15f, 0f, 0f);
        //}
    }

    IEnumerator Zoomin(float time)
    {
        transform.rotation = Quaternion.Euler(15f, 0f, 0f);
        float timer = 0;
        float fromSize = GetComponent<Camera>().orthographicSize;
        float toSize = 3;
        while(timer < time)
        {
            timer += Time.deltaTime;
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(fromSize, toSize, timer / time);

            yield return null; 
        }
    }
}

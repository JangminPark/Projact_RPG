using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private Quaternion Xcamera;

    public bool SkillOn = false;
    public float zoom;

	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
        transform.position = player.transform.position + offset;
        zoom = GetComponent<Camera>().orthographicSize = 10f;
        transform.rotation = Quaternion.Euler(10f, 0f, 0f);

        if (SkillOn == true)
        {
            zoom = GetComponent<Camera>().orthographicSize = 2f;
            transform.rotation = Quaternion.Euler(15f, 0f, 0f);
        }
	}
}

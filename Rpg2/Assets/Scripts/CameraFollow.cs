using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float camSpeed = 0.1f;
    private Camera myCam;
    private static bool cameraExits;

    // Use this for initialization
    void Start () {
        myCam = GetComponent<Camera>();
        if (!cameraExits)
        {
            cameraExits = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {

        myCam.orthographicSize = (Screen.height /25f);

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, camSpeed) + new Vector3(0f,0f,-10f) ;
        }


        
	}
}

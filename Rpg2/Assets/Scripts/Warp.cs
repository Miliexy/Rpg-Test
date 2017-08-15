using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{

    public int levelToLoad;
    public Vector2 startDirection;
   

    private void Start()
    {
        var thePlayer = GameObject.FindGameObjectWithTag("Player");
        var target = GameObject.FindGameObjectWithTag("Start");
        thePlayer.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

        var theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
   {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        yield return StartCoroutine(sf.FadeToBlack());

        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            yield return StartCoroutine(sf.FadeToClear());
        }


    }
}

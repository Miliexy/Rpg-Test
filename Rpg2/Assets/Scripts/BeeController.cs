using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BeeController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rBody;
    private bool moving;
    private float timeBTCounter;
    private float timeTMCounter;
    private Vector3 moveDirection;
    private Animator anim;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeTMCounter = Random.Range(0.1f, 3f);
        timeBTCounter = Random.Range(0.1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation pDeath = player.GetComponent<PlayerAnimation>();

        if (anim.GetBool("moving"))
        {
            timeTMCounter -= Time.deltaTime;
            rBody.velocity = moveDirection;

            if (timeTMCounter < 0f)
            {
                anim.SetBool("moving", false);
                timeBTCounter = Random.Range(0.1f, 3f);
            }

        }
        else
        {
            timeBTCounter -= Time.deltaTime;

            rBody.velocity = Vector2.zero;

            if (timeBTCounter < 0f)
            {
                anim.SetBool("moving", true);
                timeTMCounter = Random.Range(0.1f, 3f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                anim.SetFloat("Input_x", moveDirection.x / moveSpeed);
                anim.SetFloat("Input_y", moveDirection.y / moveSpeed);
            }
        }
        if (pDeath.isDeath == true )
        { 
            pDeath.Reloading();
        }
    }


}

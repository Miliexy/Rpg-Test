using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAnimation : MonoBehaviour
{

    public Vector2 move;
    public float moveSpeed;
    public float waitToReload = 1f;
    public GameObject thePlayer;
    private Rigidbody2D rbody;
    public Animator animPlayer;
    private static bool playerExits;
    public bool isDeath;

    // Use this for initialization
    void Start()
    {
        isDeath = false;
        rbody = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");

        if (!playerExits)
        {
            playerExits = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!isDeath)
        {

            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (move != Vector2.zero)
            {
                animPlayer.SetBool("isWalking", true);
                animPlayer.SetFloat("Input_x", move.x);
                animPlayer.SetFloat("Input_y", move.y);
                if(move.y == -1f)
                    animPlayer.SetFloat("Input_x", 0);
                else
                if (move.x==-1f || move.x== 1f)
                    animPlayer.SetFloat("Input_y", 0);
            }
            else
            {

                animPlayer.SetBool("isWalking", false);

            }
            rbody.MovePosition(rbody.position + move * moveSpeed * Time.deltaTime);

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            animPlayer.SetBool("isDeath", true);
        }
    }
    
    public void Reloading()
    {
        do {
            waitToReload -= Time.deltaTime;
        } while (waitToReload > 0);

    
            if (waitToReload < 0)
            {
                ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
                sf.FadeToBlack();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
                sf.FadeToClear();
            }
            //            reloading = false;
            isDeath = false;
        
    }

    private void IsDeath()
    {
        animPlayer.SetBool("isDeath", false);
        thePlayer.SetActive(false);
        isDeath = true;
    }
}

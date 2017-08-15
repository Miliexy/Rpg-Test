using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemies : MonoBehaviour {

    public PolygonCollider2D[] lstPolCols;
    public Animator animSword;
    bool kill;
    PlayerAnimation player;
   // private GameObject player;

    // Use this for initialization
    void Start () {
        animSword = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
        animSword.SetFloat("Input_x", 0f);
        animSword.SetFloat("Input_y", -1f);
        animSword.SetBool("strike", false);
        lstPolCols = gameObject.GetComponents<PolygonCollider2D>();  //use GetComponents 

    }
	
	// Update is called once per frame
	void Update () {


        animSword.SetFloat("Input_x", player.animPlayer.GetFloat("Input_x"));
        animSword.SetFloat("Input_y", player.animPlayer.GetFloat("Input_y"));
        if (animSword.GetFloat("Input_y") == -1f)
            animSword.SetFloat("Input_x", 0);
        else if (animSword.GetFloat("Input_x")!= 0)
            animSword.SetFloat("Input_y", 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.animPlayer.SetBool("strike", true);
            Debug.Log(" is pressed");
            animSword.SetBool("strike",true);

            kill = true;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy" && kill == true)
            {
                Destroy(other.gameObject);
            }
        
    }
    public void EndAnim()
    {
        Debug.Log("Key is up");
        animSword.SetBool("strike", false);
        player.animPlayer.SetBool("strike", false);
    }
    public void EnableCollider(int ix)
    {
        if (ix>0) lstPolCols[ix - 1].enabled = false;
        if (ix<3)lstPolCols[ix].enabled = true;
    } 


}

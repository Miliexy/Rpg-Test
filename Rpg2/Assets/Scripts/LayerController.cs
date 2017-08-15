using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour {

    Renderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<Renderer>();
        sprite.tag = "TreeBase";
	}
	
	// Update is called once per frame
	void Update () {
		if(sprite.transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            sprite.sortingLayerName = "TreeTop";

            Debug.Log("He is above");
        }
	}
}

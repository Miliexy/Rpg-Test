using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    Animator anim;
    bool isFading = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();	
	}

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("Fade_In");
        while (isFading)
            yield return null;
    }
    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("Fade_out");
        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
}

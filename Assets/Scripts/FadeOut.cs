using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour 
{
    Image fadeImg;
    public Animator animator;

    IEnumerator StartFade() {
        animator.SetBool("FadeOut", true);
        yield return new WaitUntil(() => fadeImg.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

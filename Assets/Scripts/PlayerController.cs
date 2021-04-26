using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float thoughtFadeOutSeconds = 1f;
    [SerializeField]
    ThoughtCounter thoughtCounter;

    // Start is called before the first frame update
    void Start()
    {
        thoughtCounter = GameObject.Find("GameManager").GetComponent<ThoughtCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Thought") {
            thoughtCounter.removeThought();
            Debug.Log("Player hit a thought");
            GameObject temp = col.gameObject;
            Destroy(col);
            Destroy(temp.GetComponent<ThoughtController>());
            temp.GetComponent<AudioSource>().Play();
            StartCoroutine(spriteFadeOut(col.gameObject.GetComponent<SpriteRenderer>(), thoughtFadeOutSeconds));
        } 
    }

    IEnumerator spriteFadeOut(SpriteRenderer sprite, float secondsToFade) {
        float timer = 0;
        //thoughtCounter.removeThought();
        while (timer < secondsToFade) {
            timer += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1, 0, timer / secondsToFade);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, newAlpha);
            
            yield return null;
        }
        Destroy(sprite.gameObject);
    }
}

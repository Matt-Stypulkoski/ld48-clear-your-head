using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThoughtCounter : MonoBehaviour
{
    [SerializeField]
    GameObject[] thoughts;
    int totalThoughts;
    [SerializeField]
    int thoughtsActive;
    [SerializeField]
    Text thoughtText;
    [SerializeField]
    Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("thoughtsFound", 0);
        thoughts = GameObject.FindGameObjectsWithTag("Thought");
        thoughtsActive = totalThoughts = thoughts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        thoughtText.text = "Thoughts Found: " + (totalThoughts - thoughtsActive) + " / " + totalThoughts;
        if (thoughtsActive == 0) {
            StartCoroutine(endGame());
        }
    }

    public void removeThought() {
        thoughtsActive -= 1;
        PlayerPrefs.SetInt("thoughtsFound", Mathf.Abs(thoughtsActive-totalThoughts));
    }

    IEnumerator endGame() {
        float timer = 0;
        while (timer < 1.5) {
            timer += Time.deltaTime;
            float newAlpha = Mathf.Lerp(0, 1, timer / 1);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);

            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

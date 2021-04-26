using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDeepText : MonoBehaviour
{
    public Text textContainer;
    bool deepest = false;
    string deepText;
    [SerializeField]
    int thoughtsFound;

    // Start is called before the first frame update
    void Start()
    {


    }

    private void Awake() {
        thoughtsFound = PlayerPrefs.GetInt("thoughtsFound");

        if (thoughtsFound == 10) {
            deepest = true;
        }

        for (int i = 0; i < thoughtsFound; i++) {
            deepText += "deep ";
        }

        if (deepest) {
            deepText += "- in fact, the deepest, ";
        }

        deepText += "sleep.";
        StartCoroutine(scrollText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator scrollText() {
        foreach (char c in deepText) {
            textContainer.text += c;
            yield return new WaitForSeconds(.1f);
        }
    }
}

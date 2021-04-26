using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 120;
    public bool timerActive = true;
    public Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(120 % 60);
    }

    // Update is called once per frame
    void Update() {
        timerText.text = getTimeInDigital(timeRemaining);
        if (timerActive) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                
            }
            else {
                timerActive = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    string getTimeInDigital(float time) {
        if (time <= 0) {
            return "0:00";
        }
        double minutes = System.Math.Floor(time / 60);
        double seconds = System.Math.Floor(time % 60);

        return minutes.ToString("0") + ":" + seconds.ToString("00");
    }
    //IEnumerator endGame() {
    //    yield return new WaitForSeconds(2);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}

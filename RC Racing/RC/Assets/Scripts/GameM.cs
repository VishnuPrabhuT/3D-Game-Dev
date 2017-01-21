using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameM : MonoBehaviour {
   
    public Text livesText;
    public Text lapText;
    public Text timerText;
    public Text speedText;
    public GameObject YouWOn;
    public GameObject gameOver;
    public GameObject car;
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1.0f;

    public static GM instance = null;
    private GameObject clonePaddle;
    public float count = 0;
    void Start () {
	
	}
	
	void Update () {
        speedDisplay();
        timerDisplay();
	}

   
    void CheckGameOver()
    {
        if (lives < 1)
        { gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
        if (bricks < 1)
        {
            YouWOn.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
    }



    public void timerDisplay()
    {


        //timerText.text = "Time : " + (float)(carSpeed);


    }


    public void speedDisplay()
    {

       
        timerText.text = "Time : " +(float)(count + Time.time);
        

    }

    


}

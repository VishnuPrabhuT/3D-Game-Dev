using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public Camera FirstPerson;
    public Camera ThirdPerson;
    static public int enemyCount=0;
    static public bool shooting = false;
    static public bool startTimer = false;
    static public bool theEnd = false;
    public float count = 60f;
    public Text counterTime;
    public GameObject GameOver;
    public GameObject TheEnd;
    public GameObject Controls;
    public Text enemyTextObj;
    public Text rewardScreen;
    public Text theEndScreen;

    // Use this for initialization
    void Start () {
        FirstPerson.enabled = true;
        ThirdPerson.enabled = false;
        TheEnd.SetActive(false);
	}
    public static void decrementEnemyCount()
    {
        enemyCount++;
        //print(enemyCount);
    }
    public static void shootingOn()
    {
        shooting = true;
    }
    public static void setTimer()
    {
        startTimer = true;
    }
    public static void stopTimer()
    {
        startTimer = false;
    }
    public static void setTheEnd()
    {
        theEnd = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FirstPerson.enabled = !FirstPerson.enabled;
            ThirdPerson.enabled = !ThirdPerson.enabled;
        }
        if (startTimer)
        {
            //print(startTimer);
            count -= Time.deltaTime;
           // float check = 180 + (int)count;
            counterTime.text = "time Left:" + ( (int)count);
            if (count < 1)
            { GameOver.SetActive(true); }
        }
        enemyTextObj.text = "Enemies Killed :  " + enemyCount + "/ 6";
        Destroy(rewardScreen, 10f);
        if (theEnd)
        {
            TheEnd.SetActive(true);
            //Destroy(TheEnd, 10f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TheEnd.SetActive(false);
            Manager.theEnd = false;
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Controls.SetActive(!Controls.activeSelf);
        }
    }

}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class GM : MonoBehaviour
{

    public static GM instance = null;
    public GameObject[] objects;
    private int currentActiveObject;

    internal GameObject cloneCollectibles;
    internal GameObject cloneMissile;

    public bool resetFlag = false;
    private GameObject cloneCar;
    private float startTime;
    internal float totalTime;
    public bool running = false;

    public ParticleSystem coinsParticles;
    public Text lapsText;
    public Text coinsText;
    public GameObject collectibles;
    public GameObject missile;
    public GameObject nitrous;
    public GameObject scoreBoard;

   

    public Text[] Score;
    public string[] times = new string[5];


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Setup();
        startTime = 0 ;
        running = true;
    }



    private void OnEnable()
    {
        currentActiveObject = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            SwitchCamera(currentActiveObject);
        }
        if (running)
        {
            totalTime = startTime + Time.time;
            coinsText.text = "Time : " + Timer(totalTime);
        }
        if (Input.GetKeyDown("p")&&resetFlag)
        {
            Reset();
        }
        if(Input.GetKeyDown("b") && resetFlag)
        {
            BonusLevel();
        }
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DirtTrack");
        resetFlag = false;
    }

    public void BonusLevel()
    {
        scoreBoard.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("RaceTrack");
        resetFlag = false;
    }

    public string Timer(float seconds)
    {
        int second = Convert.ToInt32(seconds) % 60;
        float minute = seconds / 60;
        string secondS = "00";
        string minuteS = "00";
        if (second < 10)
        {
            secondS = "0" + second.ToString();
        }
        if (minute < 10&&minute!=0)
        {
            
            minuteS = "0" + minute.ToString();
            minuteS = minuteS.Remove(2);
        }
        if (second >= 10)
        {
            secondS = second.ToString();
        }
        if (minute >= 10)
        {
            minuteS = minute.ToString();
            minuteS = minuteS.Remove(2);
        }
        return minuteS + ":" + secondS;
    }

    public void Setup()
    {
        cloneCollectibles = Instantiate(collectibles, collectibles.transform.position, Quaternion.identity) as GameObject;
        //cloneMissile = Instantiate(missile, new Vector3(-210f, 2f, -225f), Quaternion.identity) as GameObject;
    }

    public void KillNitrous()
    {
        nitrous.SetActive(false);
    }

    public void SwitchCamera(int cameraActive)
    {
        int nextactiveobject = currentActiveObject + 1 >= objects.Length ? 0 : currentActiveObject + 1;

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == nextactiveobject);
        }
        currentActiveObject = nextactiveobject;
    }
}

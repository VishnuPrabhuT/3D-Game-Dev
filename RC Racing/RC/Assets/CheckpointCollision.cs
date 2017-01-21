using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CheckpointCollision : MonoBehaviour
{
    public GameObject car;
    private bool lapCheck = false;
    private int currentLap = 0;
    private int totalLaps = 3;
    private int coinsCollected = 0;
    private int totalCoins = 8;
    private string[] times = new string[5];

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Collectibles"))
        {
            //coinsCollected++;
            //GM.instance.coinsText.text = "Coins - " + coinsCollected + " / " + totalCoins;
            col.gameObject.SetActive(false);
            GM.instance.nitrous.SetActive(true);
            Instantiate(GM.instance.coinsParticles, col.gameObject.transform.position, Quaternion.identity);
            Rigidbody rb = car.gameObject.GetComponent<Rigidbody>();
            rb.AddRelativeForce(new Vector3(0,0,300),ForceMode.Acceleration);
            Invoke("KillNitrous", 2f);
        }

        //if (col.gameObject.CompareTag("Missiles") && gameObject.tag != "Player")
        //{
        //    col.gameObject.SetActive(false);
        //    GM.instance.nitrous.SetActive(true);
        //    Instantiate(GM.instance.coinsParticles, col.gameObject.transform.position, Quaternion.identity);
        //}

        if (col.gameObject.CompareTag("Start") && lapCheck == false)
        {
            currentLap++;
            coinsCollected = 0;
            //GM.instance.coinsText.text = "Coins - " + coinsCollected + " / " + totalCoins;
            GM.instance.lapsText.text = "Lap : " + currentLap + " / " + totalLaps;
            lapCheck = true;
            Invoke("ResetFlag", 10f);
            Destroy(GM.instance.cloneCollectibles);
            Destroy(GM.instance.cloneMissile);
            GM.instance.Setup();
        }

        if (currentLap >= totalLaps)
        {
            AILapCount getObj = new AILapCount();
            
            ScoreBoard scoreBoardObj = new ScoreBoard();
            scoreBoardObj.SetScoreDetails(getObj.GetTimes());
            GM.instance.running = false;
            GM.instance.scoreBoard.SetActive(true);
            Invoke("startNewGame", 7f);
        }
    }

    void KillNitrous()
    {
        GM.instance.KillNitrous();
    }

    void ResetFlag()
    {
        lapCheck = false;
    }
    void startNewGame()
    {
        GM.instance.resetFlag = true;
    }
}

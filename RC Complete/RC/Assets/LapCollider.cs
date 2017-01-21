using UnityEngine;
using System.Collections;

public class LapCollider : MonoBehaviour
{
    private int currentLap = 0;
    private int totalLap = 3;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Start"))
        {
            currentLap++;
            GM.instance.lapsText.text = "Lap - " + currentLap + " / " + totalLap;
        }
    }
}

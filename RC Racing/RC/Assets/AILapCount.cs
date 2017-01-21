using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AILapCount : MonoBehaviour
{
    Dictionary<string, int> list = new Dictionary<string, int>();
    Dictionary<string, int> carList = new Dictionary<string, int>();
    string carNames = "OrangeJeep,BlueJeep,YellowJeep,WhiteJeep,RedJeep";
    //int[] laps = new int[5];
    string[] splitNames;
    int place = 0;
    int position=-5;
    // Use this for initialization
    void Start()
    {

        splitNames = carNames.Split(',');
        foreach (string ss in splitNames)
        {
            carList.Add(ss, 0);
        }

    }
    

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.transform.parent.gameObject.name);
        if (carNames.Contains(col.transform.parent.gameObject.name))
        {
            //Debug.Log("Here1");
            int index = Array.IndexOf(splitNames, col.transform.parent.gameObject.name);
            //Debug.Log(index);
            if (carList[col.transform.parent.gameObject.name] < 3)
            {
                //Debug.Log("Here1");
                carList[col.transform.parent.gameObject.name]++;
            }
            position = Array.IndexOf(splitNames, col.transform.parent.gameObject.name);
            //Debug.Log(position);
            if (carList[col.transform.parent.gameObject.name] == 3&& position>-1)
            {
                Debug.Log(col.transform.parent.gameObject.name);
                Debug.Log(place);
                GM.instance.times[place] = col.transform.parent.gameObject.name + "        -        " + GM.instance.Timer(GM.instance.totalTime);
                place++;
                int carKiller = Array.IndexOf(splitNames, col.transform.parent.gameObject.name);
                splitNames[carKiller] = "-";
            }
        }
    }

    public string[] GetTimes()
    {
        return GM.instance.times;
    }
}

using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{
    public void SetScoreDetails(string[] times)
    {
        for (int i = 0; i < 5; i++)
        {
            //GM.instance.Names[i].text = times[i].Split('-')[times[i].Split('-').Length-1
            //Points[i].text = playerInfo[i].point.ToString();
            GM.instance.Score[i].text = times[i].ToString();
        }
    }
}

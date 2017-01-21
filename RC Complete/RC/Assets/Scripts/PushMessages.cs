using UnityEngine;
using System.Collections;

using NarayanaGames.Common;
using NarayanaGames.ScoreFlashComponent;
using NarayanaGames.ScoreFlashComponent.Addons;
public class PushMessages : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10;

    void OnTriggerEnter(Collider col)
    {
        ScoreFlashFollow3D follow3D = GetComponent<ScoreFlashFollow3D>();
        
        
            //Debug.Log("Check");

            ScoreFlash.Instance.PushWorld(follow3D, "-5");
            //col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        
        //if (col.tag == "Bugs")
        //{
            
        //    //Debug.Log("Check");
        //    col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        //    ScoreFlash.Instance.PushWorld(follow3D, "-5");
        //}
        //if (col.tag == "Bake")
        //{
            
        //    //Debug.Log("Check");
        //    col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        //    ScoreFlash.Instance.PushWorld(follow3D, "+5");
        //}
    }



}

using UnityEngine;
using System.Collections;

public class FloorZone : MonoBehaviour {
    public bool isDamaging;
    public float damage = 10;

    void OnTriggerStay(Collider col) { 
        if (col.tag == "Player")
        {
            //Debug.Log("Check");
            col.SendMessage( (isDamaging)? "TakeDamage" :"HealDamage" , Time.deltaTime * damage );
        }
        if (col.tag == "Bugs")
        {
            //Debug.Log("Check");
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        }
        if (col.tag == "Bake")
        {
            //Debug.Log("Check");
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        }
    }
}

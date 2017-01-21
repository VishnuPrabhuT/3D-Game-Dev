using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NarayanaGames.Common;
using NarayanaGames.ScoreFlashComponent;
using NarayanaGames.ScoreFlashComponent.Addons;
public class HealthBar : MonoBehaviour
{

    public Image currentHealthBar;
    public float hitpoint = 100;
    public float maxHitPoint = 100;
    public bool isDamaging;
    public float damage = 10;

    
    // public Text ratioText;
    // Use this for initialization
    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float ratio = hitpoint / maxHitPoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //ratioText.text = (ratio*100).ToString() + '%';
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        { hitpoint = 0; }
        ScoreFlashFollow3D follow3D = GetComponent<ScoreFlashFollow3D>();
        ScoreFlash.Instance.PushWorld(follow3D, "-5");

       // GM.instance.scores[0] -= 5;
        UpdateHealthBar();
    }
    private void HealDamage(float damage)
    {
        ScoreFlashFollow3D follow3D = GetComponent<ScoreFlashFollow3D>();
        ScoreFlash.Instance.PushWorld(follow3D, "+5");
        hitpoint += damage;
        if (hitpoint > 100)
        { hitpoint = 100; }

        //GM.instance.scores[0] += 10;
        UpdateHealthBar();
    }

    void OnCollisionEnter(Collision col)
    {
        if (isDamaging)
        {
            HealDamage(damage);

        }
        else
        {

            TakeDamage(damage);
        }

        //		col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);


    }

}

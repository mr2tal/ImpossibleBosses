using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastingSpell : MonoBehaviour {
    public Image castBar;
    private float timeCasting = 0f;
    private bool isCasting = false;
    // Use this for initialization
    private void Start()
    {
        castBar.enabled = false;
    }

    private void Update()
    {

    }

    void Casting(float castTime)
    {
        isCasting = true;
        castBar.enabled = true;
            if (timeCasting < castTime)
            {
                timeCasting = Time.deltaTime + timeCasting;
                castBar.fillAmount = timeCasting / castTime;
            }
            else
            {
                timeCasting = 0f;
                castBar.enabled = false;
                isCasting = false;
                //Shoot projectile
            }
       
    }
}

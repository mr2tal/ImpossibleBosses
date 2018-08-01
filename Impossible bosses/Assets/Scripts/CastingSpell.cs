using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using System;

public class CastingSpell : MonoBehaviour {
    public Image castBar;
    public Text castBarTime;


    private float timeCasting = 0f;
    private bool isCasting = false;
    private float castTime;
    private Action<Vector3, GameObject> currentSpell;
    
    


    // Use this for initialization
    private void Start()
    {
        TalentSystem.SetSpellsChosen();
        castBar.enabled = false;
        castBarTime.text = "Filler"; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CastRequest(Spellbook.CastTime(Spellbook.KeyRep.M0, TalentSystem.m0), TalentSystem.m0);    
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CastRequest(Spellbook.CastTime(Spellbook.KeyRep.M0, TalentSystem.m1), TalentSystem.m1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastRequest(Spellbook.CastTime(Spellbook.KeyRep.Q, TalentSystem.keyQ), TalentSystem.keyQ);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CastRequest(Spellbook.CastTime(Spellbook.KeyRep.E, TalentSystem.keyE), TalentSystem.keyE);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CastRequest(Spellbook.CastTime(Spellbook.KeyRep.R, TalentSystem.keyR), TalentSystem.keyR);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            CastRequest(Spellbook.CastTime(Spellbook.KeyRep.F, TalentSystem.keyF), TalentSystem.keyF);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CancelCast();
        }
        if (isCasting == true)
        {
            Casting();
        }
    }

    void CastRequest(float castTime, Action<Vector3,GameObject> spell)
    {
        this.castTime = castTime;
        isCasting = true;
        currentSpell = spell;
        
    }

    void Casting()
    {
        isCasting = true;
        castBar.enabled = true;
            if (timeCasting < castTime)
            {
                timeCasting = Time.deltaTime + timeCasting;
                castBar.fillAmount = timeCasting / castTime;
                castBarTime.text = timeCasting + " / " + castTime; 
            }
            else
            {
                timeCasting = 0f;
                castBar.enabled = false;
                isCasting = false;
                
                //Shoot projectile
                Vector3 targetCoordinates = VectorFun.GetMouseCoordinatesOnPlane();
                currentSpell(targetCoordinates, gameObject);
                
            }
       
    }

    void CancelCast()
    {
        isCasting = false;
        castBar.enabled = false;
        timeCasting = 0f;
    }
}

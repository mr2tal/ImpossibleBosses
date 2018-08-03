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
    public float globalCooldown;
    private float[] fullCooldowns = new float[6];
    private float[] currentCooldowns = new float[6];
    private int index;


    // Use this for initialization
    private void Start()
    {
        TalentSystem.SetSpellsChosen();
        castBar.enabled = false;
        castBarTime.text = "Filler";
        fullCooldowns[0] = Spellbook.Cooldown(TalentSystem.m0);
        fullCooldowns[1] = Spellbook.Cooldown(TalentSystem.m1);
        fullCooldowns[2] = Spellbook.Cooldown(TalentSystem.keyQ);
        fullCooldowns[3] = Spellbook.Cooldown(TalentSystem.keyE);
        fullCooldowns[4] = Spellbook.Cooldown(TalentSystem.keyR);
        fullCooldowns[5] = Spellbook.Cooldown(TalentSystem.keyF);
    }

    private void Update()
    {
        if (globalCooldown <= 0) 
        {
            if (isCasting == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (currentCooldowns[0] <= 0)
                    {
                        CastRequest(Spellbook.CastTime(Spellbook.KeyRep.M0, TalentSystem.m0), TalentSystem.m0, 0);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (currentCooldowns[1] <= 0)
                    {
                        CastRequest(Spellbook.CastTime(Spellbook.KeyRep.M1, TalentSystem.m1), TalentSystem.m1, 1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (currentCooldowns[2] <= 0)
                    {
                        CastRequest(Spellbook.CastTime(Spellbook.KeyRep.Q, TalentSystem.keyQ), TalentSystem.keyQ, 2);
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (currentCooldowns[3] <= 0)
                    {
                        CastRequest(Spellbook.CastTime(Spellbook.KeyRep.E, TalentSystem.keyE), TalentSystem.keyE, 3);
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (currentCooldowns[4] <= 0)
                    {
                        CastRequest(Spellbook.CastTime(Spellbook.KeyRep.R, TalentSystem.keyR), TalentSystem.keyR, 4);
                    }
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (currentCooldowns[5] <= 0)
                    {
                        CastRequest(Spellbook.CastTime(Spellbook.KeyRep.F, TalentSystem.keyF), TalentSystem.keyF, 5);
                    }
                }
            }
            
        }else
            {
                globalCooldown = globalCooldown - Time.deltaTime;
            }
        if (isCasting == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            CancelCast();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            CancelCast();
        }
        if (isCasting == true)
        {
            Casting();
        }

        for (int i = 0; i < 6; i++)
        {
            if (currentCooldowns[i] > 0)
            {
                currentCooldowns[i] = currentCooldowns[i] - Time.deltaTime;
            }
        }
        
       
    }

    float GetFullCooldowns(int index)
    {
        return fullCooldowns[index];
    }

    void SetCurrentCooldown(int index)
    {
        currentCooldowns[index] = GetFullCooldowns(index);
    }


    void CastRequest(float castTime, Action<Vector3,GameObject> spell, int index)
    {
        this.castTime = castTime;
        isCasting = true;
        currentSpell = spell;
        globalCooldown = 0.5f;
        this.index = index;
        
    }

    void Casting()
    {
            if (castBar.enabled == false)
            {
                castBar.enabled = true;
            }
            if (timeCasting < castTime)
            {
                timeCasting = Time.deltaTime + timeCasting;
                castBar.fillAmount = timeCasting / castTime;
                castBarTime.text = timeCasting + " / " + castTime; 
            }
            else
            {
                SetCurrentCooldown(index);
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

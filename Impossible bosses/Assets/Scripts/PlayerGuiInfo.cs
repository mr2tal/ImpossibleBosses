﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerGuiInfo : MonoBehaviour {
    public Text stats;
    public Image mouse1, mouse2, keyQ, keyE, keyR, keyF;
    public Sprite mouse1_0, mouse1_1, mouse1_2;
    public Text mouse1_Cooldown, mouse2_Cooldown, keyQ_Cooldown, keyE_Cooldown, keyR_Cooldown, keyF_Cooldown;
    private CastingSpell castingSpell;
    
    // Use this for initialization
    void Start() {
        SetIcons();
        castingSpell = gameObject.GetComponent<CastingSpell>();
        Spells.instantiator = Instantiate;
    }

    // Update is called once per frame
    void Update() {
        stats.text = gameObject.GetComponent<Stats>().nick.ToString()
            + " " 
            + gameObject.name 
            + " Hp: "
            + gameObject.GetComponent<Stats>().hp.ToString()
            + " Mana: " 
            + gameObject.GetComponent<Stats>().mana.ToString();

        CurrentCooldowns();
    }

    public void CurrentCooldowns()
    {
        mouse1_Cooldown.text = (Mathf.Round(castingSpell.GetCurrentCooldown(0) * 100f) / 100).ToString();
        mouse2_Cooldown.text = (Mathf.Round(castingSpell.GetCurrentCooldown(1) * 100f) / 100).ToString();
        keyQ_Cooldown.text = (Mathf.Round(castingSpell.GetCurrentCooldown(2) * 100f) / 100).ToString();
        keyE_Cooldown.text = (Mathf.Round(castingSpell.GetCurrentCooldown(3) * 100f) / 100).ToString();
        keyR_Cooldown.text = (Mathf.Round(castingSpell.GetCurrentCooldown(4) * 100f) / 100).ToString();
        keyF_Cooldown.text = (Mathf.Round(castingSpell.GetCurrentCooldown(5) * 100f) / 100).ToString();
    }

    public void SetIcons()
    {
        if (MainSceneStartUpVars.spells[0] == 0)
        {
            mouse1.sprite = mouse1_0;
        }
        else if (MainSceneStartUpVars.spells[0] == 1)
        {
            mouse1.sprite = mouse1_1;
        }
        else if (MainSceneStartUpVars.spells[0] == 2)
        {
            mouse1.sprite = mouse1_2;
        }

        if (MainSceneStartUpVars.spells[1] == 0)
        {
            mouse2.sprite = mouse1_0;
        }
        else if (MainSceneStartUpVars.spells[1] == 1)
        {
            mouse2.sprite = mouse1_1;
        }
        else if (MainSceneStartUpVars.spells[1] == 2)
        {
            mouse2.sprite = mouse1_2;
        }

        if (MainSceneStartUpVars.spells[2] == 0)
        {
            keyQ.sprite = mouse1_0;
        }
        else if (MainSceneStartUpVars.spells[2] == 1)
        {
            keyQ.sprite = mouse1_1;
        }
        else if (MainSceneStartUpVars.spells[2] == 2)
        {
            keyQ.sprite = mouse1_2;
        }

        if (MainSceneStartUpVars.spells[3] == 0)
        {
            keyE.sprite = mouse1_0;
        }
        else if (MainSceneStartUpVars.spells[3] == 1)
        {
            keyE.sprite = mouse1_1;
        }
        else if (MainSceneStartUpVars.spells[3] == 2)
        {
            keyE.sprite = mouse1_2;
        }

        if (MainSceneStartUpVars.spells[4] == 0)
        {
            keyR.sprite = mouse1_0;
        }
        else if (MainSceneStartUpVars.spells[4] == 1)
        {
            keyR.sprite = mouse1_1;
        }
        else if (MainSceneStartUpVars.spells[4] == 2)
        {
            keyR.sprite = mouse1_2;
        }

        if (MainSceneStartUpVars.spells[5] == 0)
        {
            keyF.sprite = mouse1_0;
        }
        else if (MainSceneStartUpVars.spells[5] == 1)
        {
            keyF.sprite = mouse1_1;
        }
        else if (MainSceneStartUpVars.spells[5] == 2)
        {
            keyF.sprite = mouse1_2;
        }
    }
}

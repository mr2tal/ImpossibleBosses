using UnityEngine;
using UnityEngine.UI;
using System;

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
    }

    // Update is called once per frame
    void Update() {
        stats.text = gameObject.name 
            + " Hp: "
            + gameObject.GetComponent<Stats>().hp.ToString()
            + " Mana: " 
            + gameObject.GetComponent<Stats>().mana.ToString();

        CurrentCooldowns();
    }

    public void CurrentCooldowns()
    {
        mouse1_Cooldown.text = Mathf.Ceil(castingSpell.GetCurrentCooldown(0)).ToString();
        mouse2_Cooldown.text = Mathf.Ceil(castingSpell.GetCurrentCooldown(1)).ToString();
        keyQ_Cooldown.text =   Mathf.Ceil(castingSpell.GetCurrentCooldown(2)).ToString();
        keyE_Cooldown.text =   Mathf.Ceil(castingSpell.GetCurrentCooldown(3)).ToString();
        keyR_Cooldown.text =   Mathf.Ceil(castingSpell.GetCurrentCooldown(4)).ToString();
        keyF_Cooldown.text =   Mathf.Ceil(castingSpell.GetCurrentCooldown(5)).ToString();
    }

    public void SetIcons()
    {
        Func<Utilities.Nr3, Sprite> f = nr => {
            if (nr == Utilities.Nr3.fst) { return mouse1_0; }
            else if (nr == Utilities.Nr3.snd) { return mouse1_1; }
            else if (nr == Utilities.Nr3.thr) { return mouse1_2; }
            else { throw new Exception("Spellnumber not know."); }
        };
        mouse1.sprite = f(GlobalInfo.spellsNr[0]);
        mouse2.sprite = f(GlobalInfo.spellsNr[1]);
        keyQ.sprite =   f(GlobalInfo.spellsNr[2]);
        keyE.sprite =   f(GlobalInfo.spellsNr[3]);
        keyR.sprite =   f(GlobalInfo.spellsNr[4]);
        keyF.sprite =   f(GlobalInfo.spellsNr[5]);
    }
}

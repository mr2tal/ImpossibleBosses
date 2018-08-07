using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Utilities;

public class TalentSystem : MonoBehaviour {

    public Dropdown[] dropdowns;

    // Update is called once per frame
    void Update () {
        int counter = 0;
        foreach (Dropdown i in dropdowns){
            if (counter < 6){
                GlobalInfo.spellsNr[counter] = (Nr3)i.value;
                counter++;
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("talentSelection");
    }

    public static void SetSpellsChosen() {
        Func<Nr3, KeyRep, Spell> indexer = (nr, key) => {
            return SpellRow.index(nr, GlobalInfo.role, key);
        };
        GlobalInfo.spellbook = new SpellBook(
              indexer(GlobalInfo.spellsNr[0], KeyRep.M0)
            , indexer(GlobalInfo.spellsNr[1], KeyRep.M1)
            , indexer(GlobalInfo.spellsNr[2], KeyRep.Q)
            , indexer(GlobalInfo.spellsNr[3], KeyRep.E)
            , indexer(GlobalInfo.spellsNr[4], KeyRep.R)
            , indexer(GlobalInfo.spellsNr[5], KeyRep.F)
        );
    }
}

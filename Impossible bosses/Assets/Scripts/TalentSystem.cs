using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TalentSystem : MonoBehaviour {

    public Dropdown[] dropdowns;
    private int counter = 0;
    public static Action<Vector3, GameObject> m0;
    public static Action<Vector3, GameObject> m1;
    public static Action<Vector3, GameObject> keyQ;
    public static Action<Vector3, GameObject> keyE;
    public static Action<Vector3, GameObject> keyR;
    public static Action<Vector3, GameObject> keyF;



    // Use this for initialization
    void Start() {

    }


    // Update is called once per frame
    void Update () {
            foreach (Dropdown i in dropdowns)
        {
            if (counter < 6)
            {
                MainSceneStartUpVars.spells[counter] = i.value;
                counter = counter + 1;
            }
        }
        counter = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public static void SetSpellsChosen()
    {
        Func<string, Spellbook.RoleClass> f = x => {
            if (x == "Warrior") { return Spellbook.RoleClass.Warrior; }
            else if (x == "Mage") { return Spellbook.RoleClass.Mage; }
            else if (x == "Ranger") { return Spellbook.RoleClass.Ranger; }
            else { throw new Exception("can't cast"); }
        };
        Spellbook.RoleClass rclass = f(MainSceneStartUpVars.Pname);
        m0 =   Spellbook.index((Spellbook.Nr3)MainSceneStartUpVars.spells[0], rclass, Spellbook.KeyRep.M0);
        m1 =   Spellbook.index((Spellbook.Nr3)MainSceneStartUpVars.spells[1], rclass, Spellbook.KeyRep.M1);
        keyQ = Spellbook.index((Spellbook.Nr3)MainSceneStartUpVars.spells[2], rclass, Spellbook.KeyRep.Q);
        keyE = Spellbook.index((Spellbook.Nr3)MainSceneStartUpVars.spells[3], rclass, Spellbook.KeyRep.E);
        keyR=  Spellbook.index((Spellbook.Nr3)MainSceneStartUpVars.spells[4], rclass, Spellbook.KeyRep.R);
        keyF = Spellbook.index((Spellbook.Nr3)MainSceneStartUpVars.spells[5], rclass, Spellbook.KeyRep.F);
    }
}

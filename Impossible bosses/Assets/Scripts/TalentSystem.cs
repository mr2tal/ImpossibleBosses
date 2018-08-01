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
        if (MainSceneStartUpVars.Pname == "Warrior")
        {
            switch (MainSceneStartUpVars.spells[0])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[1])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[2])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[3])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[4])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[5])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }

        }
        if (MainSceneStartUpVars.Pname == "Ranger")
        {
            switch (MainSceneStartUpVars.spells[0])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[1])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[2])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[3])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[4])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            switch (MainSceneStartUpVars.spells[5])
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        if (MainSceneStartUpVars.Pname == "Mage")
        {
            switch (MainSceneStartUpVars.spells[0])
            {
                case 0:
                    m0 = Spellbook.index(Spellbook.Nr3.fst, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 1:
                    m0 = Spellbook.index(Spellbook.Nr3.snd, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 2:
                    m0 = Spellbook.index(Spellbook.Nr3.thr, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
            }
            switch (MainSceneStartUpVars.spells[1])
            {
                case 0:
                    m1 = Spellbook.index(Spellbook.Nr3.fst, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 1:
                    m1 = Spellbook.index(Spellbook.Nr3.snd, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 2:
                    m1 = Spellbook.index(Spellbook.Nr3.thr, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
            }
            switch (MainSceneStartUpVars.spells[2])
            {
                case 0:
                    keyQ = Spellbook.index(Spellbook.Nr3.fst, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 1:
                    keyQ = Spellbook.index(Spellbook.Nr3.snd, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 2:
                    keyQ = Spellbook.index(Spellbook.Nr3.thr, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
            }
            switch (MainSceneStartUpVars.spells[3])
            {
                case 0:
                    keyE = Spellbook.index(Spellbook.Nr3.fst, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 1:
                    keyE = Spellbook.index(Spellbook.Nr3.snd, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 2:
                    keyE = Spellbook.index(Spellbook.Nr3.thr, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
            }
            switch (MainSceneStartUpVars.spells[4])
            {
                case 0:
                    keyR = Spellbook.index(Spellbook.Nr3.fst, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 1:
                    keyR = Spellbook.index(Spellbook.Nr3.snd, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 2:
                    keyR = Spellbook.index(Spellbook.Nr3.thr, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
            }
            switch (MainSceneStartUpVars.spells[5])
            {
                case 0:
                    keyF = Spellbook.index(Spellbook.Nr3.fst, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 1:
                    keyF = Spellbook.index(Spellbook.Nr3.snd, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
                case 2:
                    keyF = Spellbook.index(Spellbook.Nr3.thr, Spellbook.RoleClass.Mage, Spellbook.KeyRep.M0);
                    break;
            }
        }
    }
}

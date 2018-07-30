using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalentSystem : MonoBehaviour {

    public Dropdown[] dropdowns;
    private int counter = 0;
    
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

    public void SetSpellsChosen()
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
    }
}

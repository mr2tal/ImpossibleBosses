using UnityEngine;
using UnityEngine.UI;

public class PlayerGuiInfo : MonoBehaviour {
    public Text stats;
    public Image mouse1, mouse2, keyQ, keyE, keyR, keyF;
    public Sprite mouse1_0, mouse1_1, mouse1_2;
    // Use this for initialization
    void Start() {
        SetIcons();
        Spells.instantiator = Instantiate;
    }

    // Update is called once per frame
    void Update() {
        stats.text = gameObject.name 
            + " Hp: "
            + gameObject.GetComponent<Stats>().hp.ToString()
            + " Mana: " 
            + gameObject.GetComponent<Stats>().mana.ToString();
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

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
}

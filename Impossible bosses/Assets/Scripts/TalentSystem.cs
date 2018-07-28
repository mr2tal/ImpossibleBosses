using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalentSystem : MonoBehaviour {

    public int talentPoints;
    public int chosenTalentMaximum;
    public Text text;

	// Use this for initialization
	void Start () {
        chosenTalentMaximum = talentPoints;
        text.text = "Talent points = " + talentPoints.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Talent points = " + talentPoints.ToString();
    }

    public void ResetTalents()
    {
        talentPoints = chosenTalentMaximum;
    }

    public void TalentClicked()
    {
        if (talentPoints > 0)
        {
            talentPoints = talentPoints - 1;
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}

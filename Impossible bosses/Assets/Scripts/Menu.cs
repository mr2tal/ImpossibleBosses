using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Canvas menu;
	// Use this for initialization
	void Start () {
        menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = !menu.enabled;
        }
	}

    public void OnClick(int choice)
    {
        switch (choice)
        {
            case 1:
                menu.enabled = !menu.enabled;
                break;
            case 2:
                break;
            case 3:
                Application.Quit();
                break;
            default:
                break;
        }
    }
}

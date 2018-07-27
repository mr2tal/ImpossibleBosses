using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public int hitPoints;
    public int mana;
    public Text text;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Hp:" + hitPoints.ToString() + " Mana:" + mana.ToString();

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }

      
	}

    private void OnTriggerEnter(Collider other)
    {
        hitPoints--;
    }
}

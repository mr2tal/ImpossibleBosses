using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int hitPoints;
    public int mana;
    public 
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
      
	}
}

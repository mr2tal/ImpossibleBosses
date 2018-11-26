using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {
    public Animator animator;
	// Use this for initialization
	void Start () {
        gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Horizontal", gameObject.GetComponentInParent<PlayerMovement>().hMov);
        animator.SetFloat("Vertical", gameObject.GetComponentInParent<PlayerMovement>().sMov);
    }
}

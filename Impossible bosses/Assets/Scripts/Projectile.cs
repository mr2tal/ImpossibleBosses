using UnityEngine;
using System;

public class Projectile : MonoBehaviour {
    public float movementSpeed = 0f;
    public float remainingRange = 0f;
    public Action OnEndOfRange = doNothing;
    public Predicate<Collider> OnHit = alwaysTrueD1;

    private static void doNothing() { }
    private static bool alwaysTrueD1(Collider collision) {
        return true;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        /* Move projectile "upwards", under the assumption that it is already 
         *   rotated such that relative-upwards is towards the target.
         */
        gameObject.transform.Translate(Vector3.up * movementSpeed);
        if(remainingRange <= 0) {
            OnEndOfRange();
            Destroy(gameObject);
        }
        else {
            remainingRange -= movementSpeed;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (OnHit(other)) {
            Destroy(gameObject);
        }
    }
}

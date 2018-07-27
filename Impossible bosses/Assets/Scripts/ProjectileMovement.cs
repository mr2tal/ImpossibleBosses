using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    public const float movementSpeed = 0.1f;

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
    }
}

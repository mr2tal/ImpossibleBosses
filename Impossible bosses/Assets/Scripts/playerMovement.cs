using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public const float movementSpeed = 3f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float hMov = Input.GetAxis("Horizontal");   // w/s horiztal movement
        float sMov = Input.GetAxis("Vertical");     // a/d sideways movement
        float dt = Time.deltaTime;                  // scale with physics time
        Vector3 changeVector = new Vector3(hMov, 0, sMov);
        changeVector *= dt * movementSpeed;
        gameObject.transform.Translate(changeVector);
    }
}

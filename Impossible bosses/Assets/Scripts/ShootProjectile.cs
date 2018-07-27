using UnityEngine;
using Utilities;

public class ShootProjectile : MonoBehaviour {
    public GameObject enemy;
    public bool isPlayer = false;
    public Rigidbody projectilePrefab;
    int timeBetweenShootCounter = shootEveryX; // used to count time between shoots
    public const int shootEveryX = 50; // shoot once every x fixed-updates

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isPlayer && Input.GetButtonDown("Fire1")) {
            Vector3 playerCoords = gameObject.transform.position;
            Vector3 targetCoordinates = VectorFun.GetMouseCoordinatesOnPlane();
            FireProjectile(playerCoords, targetCoordinates);
        }
    }

    void FixedUpdate() {
        if (!isPlayer && enemy != null) {
            if (timeBetweenShootCounter <= 0) {
                timeBetweenShootCounter = shootEveryX;
                FireProjectile(gameObject.transform.position, enemy.transform.position);
            }
            else {
                timeBetweenShootCounter--;
            }
        }
    }

    void FireProjectile(Vector3 startPos, Vector3 destinationPos) {
        Vector3 towardsEnemy = (destinationPos - startPos).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.up, towardsEnemy);
        Instantiate(projectilePrefab, startPos + towardsEnemy * 2, rotation);
    }
}

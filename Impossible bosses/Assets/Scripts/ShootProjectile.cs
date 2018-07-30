using UnityEngine;
using Utilities;

public class ShootProjectile : MonoBehaviour {
    public GameObject enemy;
    public bool isPlayer = false;
    public Projectile projectilePrefab;
    int timeBetweenShootCounter = shootEveryX; // used to count time between shoots
    public const int shootEveryX = 50; // shoot once every x fixed-updates

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isPlayer && Input.GetButtonDown("Fire1")) {
            Vector3 targetCoordinates = VectorFun.GetMouseCoordinatesOnPlane();
            Spells.Bolt(projectilePrefab, targetCoordinates, gameObject, 0.5f, 10f, 1);
        }
    }

    void FixedUpdate() {
        if (!isPlayer && enemy != null) {
            if (timeBetweenShootCounter <= 0) {
                timeBetweenShootCounter = shootEveryX;
                Spells.Bolt(projectilePrefab, enemy.transform.position, gameObject, 0.1f, 20f, 1);
            }
            else {
                timeBetweenShootCounter--;
            }
        }
    }
}

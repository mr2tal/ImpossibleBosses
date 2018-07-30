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
            Spells.FireBolt(targetCoordinates,gameObject);
        }
    }

    void FixedUpdate() {
        if (!isPlayer && enemy != null) {
            if (timeBetweenShootCounter <= 0) {
                timeBetweenShootCounter = shootEveryX;
                Spells.FireBolt(enemy.transform.position,gameObject);
            }
            else {
                timeBetweenShootCounter--;
            }
        }
    }
}

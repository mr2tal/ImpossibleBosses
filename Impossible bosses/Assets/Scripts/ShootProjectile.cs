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
            Projectile proj = FireProjectile(targetCoordinates);
            proj.movementSpeed = 0.5f;
            proj.remainingRange = 10f;
        }
    }

    void FixedUpdate() {
        if (!isPlayer && enemy != null) {
            if (timeBetweenShootCounter <= 0) {
                timeBetweenShootCounter = shootEveryX;
                Projectile proj = FireProjectile(enemy.transform.position);
                proj.movementSpeed = 0.1f;
                proj.remainingRange = 20f;
            }
            else {
                timeBetweenShootCounter--;
            }
        }
    }

    Projectile FireProjectile(Vector3 destinationPos) {
        Vector3 yzero = new Vector3(1, 0, 1);
        Vector3 size = gameObject.transform.localScale;
        Vector3 pos = gameObject.transform.position;
        Vector3 VectorTowardsEnemy = (destinationPos - pos).normalized;
        Vector3 psize = projectilePrefab.transform.localScale;
        size.Scale(yzero);
        psize.Scale(yzero);
        float extraSpawnDist = 0.0001f + size.magnitude + psize.magnitude;
        Quaternion rotation = Quaternion.LookRotation(Vector3.up, VectorTowardsEnemy);
        return Instantiate(projectilePrefab, pos + VectorTowardsEnemy * extraSpawnDist, rotation);
    }
}

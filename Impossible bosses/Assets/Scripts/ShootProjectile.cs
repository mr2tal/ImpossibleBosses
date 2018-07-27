using UnityEngine;

public class ShootProjectile : MonoBehaviour {
    public GameObject enemy;
    public bool isPlayer = false;
    public Rigidbody projectilePrefab;
    public static readonly Plane plane = new Plane(Vector3.up, Vector3.zero);
    int timeBetweenShootCounter = shootEveryX; // used to count time between shoots
    public const int shootEveryX = 50; // shoot once every x fixed-updates

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isPlayer && Input.GetButtonDown("Fire1")) {
            Vector3 playerCoords = gameObject.transform.position;
            Vector3 targetCoordinates = GetMouseCoordinatesOnPlane();
            FireProjectile(playerCoords, targetCoordinates);
        }
    }

    void FixedUpdate() {
        if (!isPlayer) {
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
        Rigidbody projectile = Instantiate(projectilePrefab, startPos + towardsEnemy * 2, rotation);
    }

    public static Vector3 GetMouseCoordinatesOnPlane() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance)) {
            return ray.GetPoint(distance);
        }
        else {
            // happens if mouse doesn't hit the plane anywhere, ie. the 
            // camera is somewhere (or at some angle) where it should not be.
            return Vector3.zero;
        }
    }
}

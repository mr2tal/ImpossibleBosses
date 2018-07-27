using UnityEngine;

public class ShootProjectile : MonoBehaviour {
    public GameObject enemy;
    public Rigidbody projectilePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")){
            Vector3 playerCoords = gameObject.transform.position;
            Vector3 enemyCoords = enemy.transform.position;
            FireProjectile(playerCoords, enemyCoords);
        }
	}

    void FireProjectile(Vector3 startPos, Vector3 destinationPos) {
        Vector3 towardsEnemy = (destinationPos - startPos).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.up, towardsEnemy);
        Rigidbody projectile = Instantiate(projectilePrefab, startPos + towardsEnemy * 2, rotation);
        projectile.velocity = new Vector3(1, 1, 1);
    }
}

using UnityEngine;
using System;

public static class Spells {
    public static Func<Projectile, Vector3, Quaternion, Projectile> instantiator = GameObject.Find("Initializer").GetComponent<MainSceneInitializer>().instanciator;
    public static Projectile prefab = GameObject.Find("Initializer").GetComponent<MainSceneInitializer>().projectilePrefab;
   

    public static readonly Vector3 yzero = new Vector3(1, 0, 1);
    public static readonly float boltSpeed = 0.2f;
    public static readonly float boltRange = 15f;
    public static readonly int boltDamage = 1;

    public static float boltSpawnDist(GameObject player) {
        Vector3 size = player.transform.localScale;
        Vector3 psize = prefab.transform.localScale;
        size.Scale(yzero);
        psize.Scale(yzero);
        return 0.0001f + size.magnitude + psize.magnitude;
    }

    public static Action<Vector3,GameObject> genericBolt(float speed, float range, int damage) {
        Action<Vector3,GameObject> retval = (dest,ob) => {
            float extraSpawnDist = boltSpawnDist(ob);
            Vector3 pos = ob.transform.position;
            Vector3 VectorTowardsEnemy = (dest - pos).normalized;
            Vector3 spawnpos = pos + VectorTowardsEnemy * extraSpawnDist;
            Quaternion rotation = Quaternion.LookRotation(Vector3.up, VectorTowardsEnemy);
            Projectile created = instantiator(prefab, spawnpos, rotation);
            created.movementSpeed = speed;
            created.remainingRange = range;
            // do nothing on end of range i.e. the default action.
            created.OnHit = y => {
                Stats Cstat = y.gameObject.GetComponent<Stats>();
                if (Cstat != null) {
                    Cstat.dealDamage(damage);
                }
                return true;
            };
        };
        return retval;
    }

    public static Action<Vector3,GameObject> FireBolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3,GameObject> SlowMovingBolt = genericBolt(boltSpeed * 0.5f, boltRange * 1.2f, boltDamage * 2);
    public static Action<Vector3, GameObject> ShortBolt = genericBolt(boltSpeed, boltRange * 0.5f, boltDamage * 3);
    public static Action<Vector3, GameObject> m1_1Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> m1_2Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> m1_3Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> Q_1Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> Q_2Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> Q_3Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> E_1Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> E_2Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> E_3Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> R_1Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> R_2Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> R_3Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> F_1Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> F_2Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3, GameObject> F_3Bolt = genericBolt(boltSpeed, boltRange, boltDamage);
}
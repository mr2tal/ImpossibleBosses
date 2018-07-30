using UnityEngine;
using System;

public static class Spells {
    public static Func<Projectile, Vector3, Quaternion, Projectile> instantiator;
    public static GameObject player;
    public static Projectile prefab;

    public static readonly Vector3 yzero = new Vector3(1, 0, 1);
    public static readonly float boltSpeed = 0.2f;
    public static readonly float boltRange = 15f;
    public static readonly int boltDamage = 1;

    public static float boltSpawnDist() {
        Vector3 size = player.transform.localScale;
        Vector3 psize = prefab.transform.localScale;
        size.Scale(yzero);
        psize.Scale(yzero);
        return 0.0001f + size.magnitude + psize.magnitude;
    }

    public static Action<Vector3> genericBolt(float speed, float range, int damage) {
        float extraSpawnDist = boltSpawnDist();
        Vector3 pos = player.transform.position;
        Action<Vector3> retval = dest => {
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

    public static Action<Vector3> FireBolt = genericBolt(boltSpeed, boltRange, boltDamage);
    public static Action<Vector3> SlowMovingBolt = genericBolt(boltSpeed * 0.5f, boltRange * 1.2f, boltDamage * 2);
}
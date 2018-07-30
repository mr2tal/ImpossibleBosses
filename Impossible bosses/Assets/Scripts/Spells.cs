using UnityEngine;
using System;

public static class Spells{
    public static Func<Projectile, Vector3, Quaternion, Projectile> instantiator;

    public static void Bolt(Projectile prefab, Vector3 dest, GameObject origin, float speed, float range, int dmg) {
        Vector3 yzero = new Vector3(1, 0, 1);
        Vector3 size = origin.transform.localScale;
        Vector3 pos = origin.transform.position;
        Vector3 VectorTowardsEnemy = (dest - pos).normalized;
        Vector3 psize = prefab.transform.localScale;
        size.Scale(yzero);
        psize.Scale(yzero);
        float extraSpawnDist = 0.0001f + size.magnitude + psize.magnitude;
        Vector3 spawnpos = pos + VectorTowardsEnemy * extraSpawnDist;
        Quaternion rotation = Quaternion.LookRotation(Vector3.up, VectorTowardsEnemy);
        Projectile created = instantiator(prefab, spawnpos, rotation);
        created.movementSpeed = speed;
        created.remainingRange = range;
        // do nothing on end of range i.e. the default action.
        created.OnHit = y => {
            Stats Cstat = y.gameObject.GetComponent<Stats>();
            if (Cstat != null) {
                Cstat.dealDamage(dmg);
            }
            return true;
        };
    }
}

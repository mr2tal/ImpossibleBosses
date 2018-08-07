using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Utilities {
    public static class SpellHelper {
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

        public static Action<Vector3, GameObject> genericBolt(float speed, float range, int damage) {
            Action<Vector3, GameObject> retval = (dest, ob) => {
                float extraSpawnDist = boltSpawnDist(ob);
                Vector3 pos = ob.transform.position;
                Vector3 VectorTowardsEnemy = (dest - pos).normalized;
                Vector3 spawnpos = pos + VectorTowardsEnemy * extraSpawnDist;
                Quaternion rotation = Quaternion.LookRotation(Vector3.up, VectorTowardsEnemy);
                Projectile created = GameObject.Instantiate(prefab, spawnpos, rotation);
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

        // melee 90' angle infront of character with 1 range.
        public static Action<Vector3, GameObject> Melee(int damage) { // this way of calculating the hit-cone infront of the target assume that all y-values in all positions is 0.
            Action<Vector3, GameObject> retval = (targetPos, player) => {
                Vector3 playerForward = (targetPos - player.transform.position).normalized;
                IEnumerable<Stats> statsInCone = VectorFun.getTagsInCone("Enemies", player.transform.position, playerForward, 10, 45)
                                                    .Select(x => x.GetComponent<Stats>());
                foreach (Stats item in statsInCone) {
                    Debug.Log(item.gameObject.tag);
                    item.dealDamage(damage);
                }
            };
            return retval;
        }

        public static Action<Vector3, GameObject> FireBolt = genericBolt(boltSpeed, boltRange, boltDamage);
        public static Action<Vector3, GameObject> SlowMovingBolt = genericBolt(boltSpeed * 0.5f, boltRange * 1.2f, boltDamage * 2);
        public static Action<Vector3, GameObject> ShortBolt = genericBolt(boltSpeed, boltRange * 0.5f, boltDamage * 3);
        public static Action<Vector3, GameObject> standardBolt = genericBolt(boltSpeed, boltRange, boltDamage);
    }
}
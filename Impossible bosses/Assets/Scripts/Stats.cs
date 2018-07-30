using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    public int hp { get; private set; }
    public int mana { get; private set; }
    public float mspeed { get; private set; }
    // buffs.
    private Queue<int> dmgq = new Queue<int>();

    public void dealDamage(int dmg) {
        dmgq.Enqueue(dmg);
    }
    private void FixedUpdate() {
        while(dmgq.Count > 0) {
            hp -= dmgq.Dequeue();
        }

        if(hp <= 0) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        if (gameObject.GetComponent<ShootProjectile>().isPlayer) {
            hp = MainSceneStartUpVars.Php;
            mana = MainSceneStartUpVars.Pmana;
            mspeed = MainSceneStartUpVars.Pmovesp;
            gameObject.name = MainSceneStartUpVars.Pname;
        }
        else {
            hp = MainSceneStartUpVars.Ehp;
            mana = MainSceneStartUpVars.Emana;
            mspeed = MainSceneStartUpVars.Emovesp;
            gameObject.name = MainSceneStartUpVars.Ename;
        }
    }
}

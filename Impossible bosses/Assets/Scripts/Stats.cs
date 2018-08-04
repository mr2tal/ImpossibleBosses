using UnityEngine;

public class Stats : MonoBehaviour {
    public int hp { get; private set; }
    public int mana { get; private set; }
    public float mspeed { get; private set; }
    // buffs.

    public void dealDamage(int dmg) {
        hp -= dmg;
    }

    private void FixedUpdate() {
        if (hp <= 0) {
            Destroy(gameObject, 0.4f);
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

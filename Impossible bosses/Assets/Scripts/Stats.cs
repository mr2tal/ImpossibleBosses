using UnityEngine;

public class Stats : MonoBehaviour {
    public int hp { get; private set; }
    public int mana { get; private set; }
    public float mspeed { get; private set; }
    public float aggro { get; private set; }
    public string nick { get; private set; }
    // buffs.

    public void dealDamage(int dmg) {
        hp -= dmg;
    }

    public void dealAggro(float spellAggro)
    {
        aggro = aggro + spellAggro;
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
            nick = MainSceneStartUpVars.Pnick;
        }
        else {
            hp = MainSceneStartUpVars.Ehp;
            mana = MainSceneStartUpVars.Emana;
            mspeed = MainSceneStartUpVars.Emovesp;
            gameObject.name = MainSceneStartUpVars.Ename;
        }
    }
}

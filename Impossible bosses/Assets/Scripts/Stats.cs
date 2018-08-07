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
        if (gameObject.tag == "Players") {
            hp = GlobalInfo.player.hp ;
            mana = GlobalInfo.player.mana;
            mspeed = GlobalInfo.player.moveSpeed;
            gameObject.name = GlobalInfo.player.name;
        }
        else {
            hp = GlobalInfo.boss.hp;
            mana = GlobalInfo.boss.mana;
            mspeed = GlobalInfo.boss.moveSpeed;
            gameObject.name = GlobalInfo.boss.name;
        }
    }
}

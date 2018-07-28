using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public Text text;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        text.text = PlayerStatsStatic.name + " Hp: " + PlayerStatsStatic.HP.ToString() + " Mana: " + PlayerStatsStatic.Mana.ToString();

        if (PlayerStatsStatic.HP <= 0) {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other) {
        PlayerStatsStatic.HP--;
    }
}

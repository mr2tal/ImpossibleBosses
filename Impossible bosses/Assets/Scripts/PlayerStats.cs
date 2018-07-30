using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public Text stats;
    public Image mouse1, mouse2, keyQ, keyE, keyR, keyF;
    public Sprite mouse1_0, mouse1_1, mouse1_2;
    // Use this for initialization
    void Start() {

        SetIcons();



    }

    // Update is called once per frame
    void Update() {
        stats.text = PlayerStatsStatic.name + " Hp: " + PlayerStatsStatic.HP.ToString() + " Mana: " + PlayerStatsStatic.Mana.ToString();

        if (PlayerStatsStatic.HP <= 0) {
            Destroy(gameObject);
        }


    }

    public void SetIcons()
    {
        if (PlayerStatsStatic.Spells[0] == 0)
        {
            mouse1.sprite = mouse1_0;
        }
        else if (PlayerStatsStatic.Spells[0] == 1)
        {
            mouse1.sprite = mouse1_1;
        }
        else if (PlayerStatsStatic.Spells[0] == 2)
        {
            mouse1.sprite = mouse1_2;
        }

        if (PlayerStatsStatic.Spells[1] == 0)
        {
            mouse2.sprite = mouse1_0;
        }
        else if (PlayerStatsStatic.Spells[1] == 1)
        {
            mouse2.sprite = mouse1_1;
        }
        else if (PlayerStatsStatic.Spells[1] == 2)
        {
            mouse2.sprite = mouse1_2;
        }

        if (PlayerStatsStatic.Spells[2] == 0)
        {
            keyQ.sprite = mouse1_0;
        }
        else if (PlayerStatsStatic.Spells[2] == 1)
        {
            keyQ.sprite = mouse1_1;
        }
        else if (PlayerStatsStatic.Spells[2] == 2)
        {
            keyQ.sprite = mouse1_2;
        }

        if (PlayerStatsStatic.Spells[3] == 0)
        {
            keyE.sprite = mouse1_0;
        }
        else if (PlayerStatsStatic.Spells[3] == 1)
        {
            keyE.sprite = mouse1_1;
        }
        else if (PlayerStatsStatic.Spells[3] == 2)
        {
            keyE.sprite = mouse1_2;
        }

        if (PlayerStatsStatic.Spells[4] == 0)
        {
            keyR.sprite = mouse1_0;
        }
        else if (PlayerStatsStatic.Spells[4] == 1)
        {
            keyR.sprite = mouse1_1;
        }
        else if (PlayerStatsStatic.Spells[4] == 2)
        {
            keyR.sprite = mouse1_2;
        }

        if (PlayerStatsStatic.Spells[5] == 0)
        {
            keyF.sprite = mouse1_0;
        }
        else if (PlayerStatsStatic.Spells[5] == 1)
        {
            keyF.sprite = mouse1_1;
        }
        else if (PlayerStatsStatic.Spells[5] == 2)
        {
            keyF.sprite = mouse1_2;
        }
    }
}

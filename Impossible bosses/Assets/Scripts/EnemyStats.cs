using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {
    public Text text;
    public Image enemyHealthBar;
    private float startHP;

    void Start()
    {
        startHP = EnemyStatsStatic.HP;
    }
    void Update()
    {
        text.text =EnemyStatsStatic.name + " Hp: " + EnemyStatsStatic.HP.ToString() + " Mana: " + EnemyStatsStatic.Mana.ToString();
        enemyHealthBar.fillAmount = EnemyStatsStatic.HP / startHP;

        if (EnemyStatsStatic.HP <= 0)
        {
            Destroy(gameObject);
        }


    }
}

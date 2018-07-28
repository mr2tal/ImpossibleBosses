using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {
    public Text text;
    void Update()
    {
        text.text =EnemyStatsStatic.name + " Hp: " + EnemyStatsStatic.HP.ToString() + " Mana: " + EnemyStatsStatic.Mana.ToString();

        if (EnemyStatsStatic.HP <= 0)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyStatsStatic.HP--;
    }
}

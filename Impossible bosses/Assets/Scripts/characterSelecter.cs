using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSelecter : MonoBehaviour {

    public Vector3 playerSpawnPos = new Vector3(0, 1, 0);

    public void StartGame(int selectionChoice)
    {
      
        if (selectionChoice == 1)
        {
            PlayerStatsStatic.HP = 10;
            PlayerStatsStatic.Mana = 2;
            PlayerStatsStatic.MovementSpeed = 5;
        }
        if (selectionChoice == 2)
        {
            PlayerStatsStatic.HP = 5;
            PlayerStatsStatic.Mana = 5;
            PlayerStatsStatic.MovementSpeed = 5;
        }
        if (selectionChoice == 3)
        {
            PlayerStatsStatic.HP = 3;
            PlayerStatsStatic.Mana = 10;
            PlayerStatsStatic.MovementSpeed = 5;
        }
        SceneManager.LoadScene(1);


    }
    public void EnemyChoice(int selectionChoice)
    {
        if (selectionChoice == 1)
        {
            EnemyStatsStatic.HP = 10;
            EnemyStatsStatic.Mana = 5;
            EnemyStatsStatic.MovementSpeed = 5;
        }
        if (selectionChoice == 2)
        {
            EnemyStatsStatic.HP = 20;
            EnemyStatsStatic.Mana = 10;
            EnemyStatsStatic.MovementSpeed = 10;
        }
    }
}

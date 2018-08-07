using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelecter : MonoBehaviour {
    public Text choiceText;
    
    void Start()
    {
        EnemyChoice(1); 
    }

    void Update()
    {
        choiceText.text = "Enemy: " + GlobalInfo.boss.name;    
    }

    private static void setP(string name, int hp, int mana, float movespeed) {
        GlobalInfo.player = new LoadingStats(name, hp, mana, movespeed);
    }
    private static void setE(string name, int hp, int mana, float movespeed) {
        GlobalInfo.boss = new LoadingStats(name, hp, mana, movespeed);
    }

    public void StartGame(int selectionChoice)
    {
      
        if (selectionChoice == 1)
        {
            setP("Warrior",10,2,5);
            GlobalInfo.role = Utilities.RoleClass.Warrior;
        }
        if (selectionChoice == 2)
        {
            setP("Ranger", 5, 5, 5);
            GlobalInfo.role = Utilities.RoleClass.Ranger;
        }
        if (selectionChoice == 3)
        {
            setP("Mage", 3, 10, 5);
            GlobalInfo.role = Utilities.RoleClass.Mage;
        }
        SceneManager.LoadScene("playingMap");


    }
    public void EnemyChoice(int selectionChoice)
    {
        if (selectionChoice == 1)
        {
            setE("Easy Boss", 10, 5, 5);
        }
        if (selectionChoice == 2)
        {
            setE("Hard Boss", 20, 10, 10);
        }
    }
}

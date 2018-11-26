using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterSelecter : MonoBehaviour {
    public Text choiceText;
    public Text nickText;



    void Start()
    {
        EnemyChoice(1); 
    }

    void Update()
    {
        choiceText.text = "Enemy: " + MainSceneStartUpVars.Ename;    
    }

    private static void setP(string name, int hp, int mana, float movespeed, string nick) {
        MainSceneStartUpVars.Pnick = nick;
        MainSceneStartUpVars.Pname = name;
        MainSceneStartUpVars.Php = hp;
        MainSceneStartUpVars.Pmana = mana;
        MainSceneStartUpVars.Pmovesp = movespeed;
    }
    private static void setE(string name, int hp, int mana, float movespeed) {
        MainSceneStartUpVars.Ename = name;
        MainSceneStartUpVars.Ehp = hp;
        MainSceneStartUpVars.Emana = mana;
        MainSceneStartUpVars.Emovesp = movespeed;
    }

    public void StartGame(int selectionChoice)
    {
      
        if (selectionChoice == 1)
        {
            setP("Warrior", 10, 2, 5, nickText.text.ToString());
        }
        if (selectionChoice == 2)
        {
            setP("Ranger", 5, 5, 10, nickText.text.ToString());
        }
        if (selectionChoice == 3)
        {
            setP("Mage", 3, 10, 3, nickText.text.ToString());
        }
        SceneManager.LoadScene(1);


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

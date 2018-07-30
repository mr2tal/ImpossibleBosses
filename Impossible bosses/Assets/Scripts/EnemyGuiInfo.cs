using UnityEngine;
using UnityEngine.UI;

public class EnemyGuiInfo : MonoBehaviour {
    public Text text;
    public Image enemyHealthBar;
    private float startHP;

    void Start()
    {
        startHP = MainSceneStartUpVars.Ehp;
    }
    void Update()
    {
        text.text = gameObject.name
            + " Hp: "
            + gameObject.GetComponent<Stats>().hp.ToString()
            + " Mana: "
            + gameObject.GetComponent<Stats>().mana.ToString();


        enemyHealthBar.fillAmount = gameObject.GetComponent<Stats>().hp / startHP;
    }
}

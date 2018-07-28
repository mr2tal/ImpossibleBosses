using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class PlayerStatsStatic {

    public static int Hp, mana, movementSpeed;
    public static string name;

    public static int HP
    {
        get
        {
            return Hp;
        }
        set
        {
            Hp = value;
        }
    }
    public static int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            mana = value;
        }
    }
    public static int MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }
    public static string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class PlayerStatsStatic {

    public static float Hp, mana, movementSpeed;
    public static string name;
    public static float[] spells = new float[6];

    public static float[] Spells
    {
        get
        {
            return spells;
        }
        set
        {
            spells = value;
        }
    }
    public static float HP
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
    public static float Mana
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
    public static float MovementSpeed
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

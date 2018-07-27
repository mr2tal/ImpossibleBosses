using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStatsStatic {
    public static int Hp, mana, movementSpeed;

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
}

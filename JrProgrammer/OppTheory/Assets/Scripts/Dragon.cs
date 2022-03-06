using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    public Dragon()
    {
        Debug.Log("1st Dragon Constructor called");
        health = 100;
        stamina = 50;
        damage = 20;

        SetInfo();
    }

    public override string Attack(string infoToMod)
    {
        return infoToMod += "The Dragon burns everything that is in his way\n";
    }

    public override string Heal(string infoToMod)
    {
        return infoToMod += "The Dragon regenerates himself over timen\n";
    }

    public override string StrStats(string infoToMod)
    {
        Debug.Log("strtats tomaaaaa");
        return infoToMod += "\nHealt: " + health +
                            "\nStamina: " + stamina +
                            "\nDamage: " + damage;
    }
}
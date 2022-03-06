using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Enemy
{
    public Troll()
    {
        Debug.Log("Troll Constructor called");
        health = 10;
        stamina = 20;
        damage = 5;

        SetInfo();
    }

    public override string Attack(string infoToMod)
    {
        return infoToMod += "The Troll deal damage by smashing their foes\n";
    }

    public override string StrStats(string infoToMod)
    {
        return infoToMod += "\nHealt: " + health +
                            "\nStamina: " + stamina +
                            "\nDamage: " + damage;
    }
}

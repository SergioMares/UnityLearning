using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract because it will never be instanciated but other classes will inherit from this one
public abstract class Enemy
{
    protected int health,
                  stamina,
                  damage;

    public string enemyInfo { get; private set; }
    //It's a property, now it's read only

    public Enemy()
    {
        Debug.Log("Enemy constructor called");
        //SetInfo();
        //work but only without the StrStats because it loads the Enemy values
        //and not te child values. This because it constructs first here and then 
        //in the child.
    }

    //define once, use in every child
    public void SetInfo()
    {
        enemyInfo = Attack(enemyInfo);
        enemyInfo = Heal(enemyInfo);
        enemyInfo = StrStats(enemyInfo);
    }

    //virtual so they can be overriden. If not, they serve as
    //default method
    public virtual string Attack(string infoToMod)
    {
        return infoToMod += "This Enemy can't do damage\n";
    }

    public virtual string Heal(string infoToMod)
    {
        return infoToMod += "This Enemy can't heal\n";
    }

    //abstract so every child must define this method
    public abstract string StrStats(string infoToMod);
    
}

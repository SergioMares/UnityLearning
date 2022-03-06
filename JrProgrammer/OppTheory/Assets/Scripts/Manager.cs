using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Manager : MonoBehaviour
{
    private TextMeshProUGUI enemyStatsText;
    Enemy enemyToShow;

    // Start is called before the first frame update
    void Start()
    {
        enemyStatsText = GameObject.Find("Stats Info Text").GetComponent<TextMeshProUGUI>();
    }

    public void ShowDragon()
    {
        enemyToShow = new Dragon();
        enemyStatsText.text = enemyToShow.enemyInfo;
        //enemyToShow.enemyInfo = "this will cause an error cus is read only";
    }

    public void ShowTroll()
    {
        enemyToShow = new Troll();
        enemyStatsText.text = enemyToShow.enemyInfo;
    }

    private void Test()
    {
        /*Enemy myEnemy = new Troll();
        myEnemy.Attack();
        myEnemy.Heal();

        myEnemy = new Dragon();
        myEnemy.Attack();
        myEnemy.Heal();

        Troll myTroll = (Troll)myEnemy;
        myTroll.Attack();*/
    }
}

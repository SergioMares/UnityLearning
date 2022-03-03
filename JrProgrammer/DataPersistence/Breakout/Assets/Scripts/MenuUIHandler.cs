using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuUIHandler : MonoBehaviour
{       
    public void  SaveNameInput()
    {
        DataManager.Instance.actualPlayerName = GameObject.Find("Name Input").GetComponent<TMP_InputField>().text.ToString();
        //Debug.Log(GameObject.Find("Name Input").GetComponent<TMP_InputField>().text);        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else   
        Application.Quit();
    #endif
    }
}
            
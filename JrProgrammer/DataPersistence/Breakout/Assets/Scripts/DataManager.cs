using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName, actualPlayerName;
    public int playerScore;    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadStats();
        Debug.Log(Application.persistentDataPath);
    }   

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveStats()
    {        
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadStats()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerScore = data.playerScore;
            playerName = data.playerName;
        }
        else
        {
            Debug.Log("nohay pero yahay");
            SaveStats();
        }
    }
}

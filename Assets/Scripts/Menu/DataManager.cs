using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int scores;
    public string playerName;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadData();
    }

    [System.Serializable]
    class Data
    {
        public string name;
        public int scores;
    }

    public void SaveData()
    {
        Data playerData = new Data();
        playerData.name = playerName;
        playerData.scores = scores;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/jsonSaveData.json", json);
    }

    public void LoadData()
    {
        string jsonDataPath = Application.persistentDataPath + "/jsonSaveData.json";
        if (File.Exists(jsonDataPath))
        {
            string jsonData = File.ReadAllText(jsonDataPath);

            Data playerData = JsonUtility.FromJson<Data>(jsonData);

            scores = playerData.scores;
            playerName = playerData.name;
        }

    }


}

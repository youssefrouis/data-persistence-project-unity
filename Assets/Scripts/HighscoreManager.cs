using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    public int highscore;
    public string playerName;
    public string highscorePlayerName;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadHighscoreData();
    }
    [Serializable]
    public class SaveHighscore
    {
        public int savedHighscore;
        public string savedPlayerName;
    }

    public void SaveHighscoreData()
    {
        SaveHighscore saveHighscore = new SaveHighscore();
        saveHighscore.savedHighscore = highscore;
        saveHighscore.savedPlayerName = playerName;
        string data = JsonUtility.ToJson(saveHighscore);
        File.WriteAllText(Application.persistentDataPath + "/savefiles.json", data);
    }
    public void LoadHighscoreData()
    {
        string path = Application.persistentDataPath + "/savefiles.json";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            SaveHighscore saveHighscore = JsonUtility.FromJson<SaveHighscore>(data);
            highscore = saveHighscore.savedHighscore;
            highscorePlayerName = saveHighscore.savedPlayerName;
        }
    }

}

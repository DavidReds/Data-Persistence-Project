using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string bestName;
    public string currentName;
    public int bestScore;
    // Start is called before the first frame update

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //LoadScore(); 
    }
    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;

    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            bestName = data.bestName;
            bestScore = data.bestScore;
        }
    }
}

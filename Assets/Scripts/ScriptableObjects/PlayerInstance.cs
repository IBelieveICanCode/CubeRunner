using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInstance", menuName = "Player", order = 51)]
public class PlayerInstance : ScriptableObject
{
    public string Name = "PlayerName";
    public float Coins = 0f;
    public float BestScore = 0f;


    /*
    public void Save()
    {
        //var dir = @"C:\playerInfo.dat";// Application.persistentDataPath + "/playerInfo.dat";
        //if (!Directory.Exists(dir))
        //    Directory.CreateDirectory(dir);

        if (!File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Close();
        }
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        //FileStream file = File.Open(dir, FileMode.Open);
        PlayerData data = new PlayerData { Name= this.Name, Coins = this.Coins, BestScore = this.BestScore};
        bf.Serialize(file, data);        
    }
    */
    public void SaveAsJSON()
    {
        string path = Application.persistentDataPath + "/playerInfo.json";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        PlayerData data = new PlayerData { Name = this.Name, Coins = this.Coins, BestScore = this.BestScore };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
        Debug.Log("Saving as JSON: " + json);
    }

    public void LoadAsJSON()
    {
        string path = Application.persistentDataPath + "/playerInfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = new PlayerData { Name = "", Coins = 0f, BestScore = 0f };
            data = JsonUtility.FromJson<PlayerData>(json);
            Name = data.Name;
            Coins = data.Coins;
            BestScore = data.BestScore;
            Debug.Log(json);
        }
    }
    /*
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Name = data.Name;
            Coins = data.Coins;
            BestScore = data.BestScore;
        }
    }
    */
}

[System.Serializable]
public class PlayerData
{
    public string Name;
    public float Coins;
    public float BestScore;
}

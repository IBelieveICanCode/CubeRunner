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

    public void Save()
    {
        //var dir = @"C:\playerInfo.dat";// Application.persistentDataPath + "/playerInfo.dat";
        //if (!Directory.Exists(dir))
        //    Directory.CreateDirectory(dir);

        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            FileStream fs = new FileStream(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
            fs.Close();
        }
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        //FileStream file = File.Open(dir, FileMode.Open);
        PlayerData data = new PlayerData { Name= this.Name, Coins = this.Coins, BestScore = this.BestScore};
        bf.Serialize(file, data);        
    }

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

}

[System.Serializable]
public class PlayerData
{
    public string Name;
    public float Coins;
    public float BestScore;
}

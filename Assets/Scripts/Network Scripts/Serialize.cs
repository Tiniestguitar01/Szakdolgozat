using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Serialize
{
    Network network;

    string saveFilePath;

    public Serialize(Network network)
    {
        this.network = network;
    }

    public void Save(string name)
    {
        string networkJSON = JsonUtility.ToJson(network);
        saveFilePath = Application.persistentDataPath + "/" + name + ".json";
        File.WriteAllText(saveFilePath, networkJSON);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(networkJSON);
    }

    public Network Load(string name)
    {
        saveFilePath = Application.persistentDataPath + "/" + name + ".json";
        if (File.Exists(saveFilePath))
        {
            string networkJSON = File.ReadAllText(saveFilePath);
            network = JsonUtility.FromJson<Network>(networkJSON);
            return network;
        }
        return null;
    }
}

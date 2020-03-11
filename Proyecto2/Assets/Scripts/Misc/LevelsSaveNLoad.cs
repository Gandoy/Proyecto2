using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LevelsSaveNLoad : MonoBehaviour
{
    public static LevelsSaveNLoad instance;
    public Dictionary<int, bool> Levels = new Dictionary<int, bool>();
    [SerializeField]
    private string SaveName;
    
    public void delete()
    {
        Levels = new Dictionary<int, bool>();
        Save();
    }
    void Start()
    {
        if (instance == null)
            instance = this;
        Load();
    }
    public void LvlComplete(int index)
    {
        if (!Levels.ContainsKey(index))
        Levels.Add(index, true);
        Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Load()
    {
        string Destination = Application.persistentDataPath + SaveName;
        FileStream file;
        if (File.Exists(Destination)) file = File.OpenRead(Destination);
        else
        {
            //Debug.Log("no hay archivo vieja");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        Levels = (Dictionary<int,bool>)bf.Deserialize(file);
        file.Close();
    }
    public void Save()
    {
        string Destination = Application.persistentDataPath + SaveName;
        Debug.Log(Destination);
        FileStream file;
        if (File.Exists(Destination)) file = File.OpenWrite(Destination);
        else
            file = File.Create(Destination);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, Levels);
        file.Close();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class PowerUpController : MonoBehaviour {

    public static PowerUpController instance;
    
    //cuando hize esta lista solo dios y yo sabiamos por que la hize lista y no array, ahora solo dios lo sabe -Nico C.
    [SerializeField]
    private List<bool> PUps;
    [SerializeField]
    private string SaveName;
    [SerializeField]
    private Player P;
    [SerializeField]
    private bool[] weapons = new bool[3];

    public bool[] Weapons ()
    {
        return weapons;
    }


    public void Apply()
    {
        int ExtraHP = 0;
        foreach(bool B in PUps)
        {
            if(B)
            {
                ExtraHP++;
            }
        }
        P.SetMaxHP(ExtraHP);
    }

    public bool CheckPup(int index)
    {
        return PUps[index];
    }
    public bool CheckWpn(int index)
    {
        return weapons[index];
    }
    public void SetPup(int Index, bool B=true)
    {
        PUps[Index] = B;
        Apply();
    }
    private void Awake()
    {
        if (instance==null)
        {
            
            instance = this;
           // DontDestroyOnLoad(this.gameObject);
            Load();
            Apply();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Save()
    {
        string Destination = Application.persistentDataPath + SaveName;
        Debug.Log(Destination);
        FileStream file;
        if (File.Exists(Destination)) file=File.OpenWrite(Destination);
        else
            file=File.Create(Destination);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, PUps);
        file.Close();
    }
    private void Load()
    {
        string Destination = Application.persistentDataPath + SaveName;
        FileStream file;
        if (File.Exists(Destination)) file = File.OpenRead(Destination);
        else
        {
            Debug.Log("no hay archivo vieja");
            return;   
        }
        BinaryFormatter bf = new BinaryFormatter();
        PUps = (List<bool>)bf.Deserialize(file);
        file.Close();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundFlag : MonoBehaviour
{
    public static MenuSoundFlag instance;
    public bool Muted = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("seinstancio");
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    public void SoundSwap()
    {
        Muted = !Muted;
    }
}

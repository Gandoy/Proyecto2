﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool Muted;
    [SerializeField]
    private GameObject crossedaudio;
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void Nivel3()
    {
        SceneManager.LoadScene("Nivel3");
    }
    public void MuteUnMute()
    {
        if(!Muted)
        {
            AudioListener.volume = 0;
            Muted = true;
            crossedaudio.SetActive(false);
        }
        else
        {
            crossedaudio.SetActive(true);
            AudioListener.volume = 1;
            Muted = false;
        }
        MenuSoundFlag.instance.SoundSwap();
        
    }
    public void Start()
    {
        Debug.Log("entroastarm menu");
        if (MenuSoundFlag.instance.Muted)
        {
            Debug.Log("busca instnace");
            MuteUnMute();
        }
    }

}

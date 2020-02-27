﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject MenuPausaUI;
    [SerializeField]
    private GameObject Stones;

    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Continuar()
    {
        MenuPausaUI.SetActive(false);
        Stones.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }
    void Pausa()
    {
        MenuPausaUI.SetActive(true);
        Stones.SetActive(true);
       // anim.Play("Rise");
        Time.timeScale = 0f;
        JuegoPausado = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Salir()
    {
        Application.Quit();
    }
}

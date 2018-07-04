using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
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
}

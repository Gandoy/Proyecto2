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
    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel1-2");
    }
    public void Nivel3()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void Nivel4()
    {
        SceneManager.LoadScene("Nivel2-2");
    }
    public void Nivel5()
    {
        SceneManager.LoadScene("Boss5");
    }
    public void Nivelboss4()
    {
        SceneManager.LoadScene("Boss4");
    }
}

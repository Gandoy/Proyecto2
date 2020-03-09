using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject MenuPausaUI;
    [SerializeField]
    private GameObject Stones;
    public static MenuPausa instance;
    public Animator anim;
    [SerializeField]
    private List<GameObject> buttons;
    private bool muted = false;
    [SerializeField]
    private GameObject Soundlock;
    

    private void Awake()
    {
        instance = this;
        if(MenuSoundFlag.instance!=null)
        if (MenuSoundFlag.instance.Muted)
        {
            Mute();
        }
    }
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
        Soundlock.SetActive(false);
        foreach (GameObject i in buttons)
        {
            i.SetActive(false);
        }
        MenuPausaUI.SetActive(false);
        Stones.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }
    void Pausa()
    {
        foreach (GameObject i in buttons)
        {
            i.SetActive(true);
        }
        if (!muted) Soundlock.SetActive(true);
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
    public void PauseUnPause()
    {
        if (JuegoPausado)
            Continuar();
        else
            Pausa();
    }
    //esto lo tendria que llamar desde el input receiver pero para ahorrar tiempo buildeando escenas lo llamo desde boton
    public void Mute()
    {
        AudioListener.volume = 0;
        muted = true;
        Soundlock.SetActive(false);
    }
    public void Unmute()
    {
        AudioListener.volume = 1;
        muted = false;
        Soundlock.SetActive(true);
    }
    public void MuteUnmute()
    {
        if (muted)
        {
            Unmute();
        }
            
        else
        {
            Mute();
        }
        
    }
}

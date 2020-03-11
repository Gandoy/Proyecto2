using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaTimed : MonoBehaviour
{
    [SerializeField]
    private string Escena;
    [SerializeField]
    private float delay;
    void Start()
    {
        Invoke("Cambio", delay);
    }
    //este script no esta asociado con el pro
    private void Cambio()
    {
        SceneManager.LoadScene(Escena);

    }


}

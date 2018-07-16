using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscenaOnTrigger : MonoBehaviour {

    public string Escena;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Escena);
    }
}

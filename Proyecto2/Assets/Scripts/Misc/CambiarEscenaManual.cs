using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscenaManual : MonoBehaviour
{
    [SerializeField]
    private string SceneName;

    public void CambiarE()
    {
        SceneManager.LoadScene(SceneName);
    }
}

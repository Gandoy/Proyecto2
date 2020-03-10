using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelOrDie : MonoBehaviour
{
    [SerializeField]
    int Index;
    // Start is called before the first frame update
    void Start()
    {
        //si, lo termine tratando como un hashset por que soy un gil que se olvido que los diccionarios estan en null por default, matenme.
        if (LevelsSaveNLoad.instance.Levels.ContainsKey(Index))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitMeUp : MonoBehaviour
{
    public static LitMeUp instance;
    [SerializeField]
    private GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void Lit()
    {
        if(tutorial!=null)
        tutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

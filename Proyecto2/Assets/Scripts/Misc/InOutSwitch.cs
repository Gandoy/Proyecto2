using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutSwitch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Things;
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject x in Things)
        {
            x.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject x in Things)
        {
            x.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

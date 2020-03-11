using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIcons : MonoBehaviour
{
    public static WeaponIcons instance;
    [SerializeField]
    private GameObject[] icons;
   
    public void WpnSwitch (int W)
    {
        Debug.Log("w= " +W);
        for(int c=0;c<icons.Length;c++)
        {
            Debug.Log("entro al for");
            if (c == W)
                icons[c].SetActive(true);
            else
                icons[c].SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

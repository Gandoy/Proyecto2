using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDestruible :Character
{
    private int CurrentPhase=0;
    [SerializeField]
    private List<Texture> Texturas = new List<Texture>();
    private Renderer rend;

    public void Awake()
    {
        rend = GetComponent<Renderer>();
    }


    public override void GetDamaged(int Damage)
    {
        //Debug.Log("entrogetDamaged");
        if (CurrentPhase < Texturas.Count)
        {
            CurrentPhase++;
            rend.material.mainTexture = Texturas[CurrentPhase];
        }
        else
        {
            Instantiate(SFXondeath, transform.position, transform.rotation);
            //aca se romperia la pared
            Destroy(gameObject);
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    [SerializeField]
    private Character Char;
    [SerializeField]
    private GameObject gameobject;
    public bool flashes;
    
   // public float FlashDuration;
    public float Flashtime;
    public float Flashes;
   


    public virtual void GetHit(int damage)
    {
       // Debug.Log("entroGetHit");
        Char.GetDamaged(damage);
        if (flashes)
        {
            DamageFlash();
            //DamageFlashStart();
        }
       
    }
   /* private void Update()
    {
        if (true)
        {
            DamageFlash();
        }
    }*/
   /* private void DamageFlashStart()
    {
     InvokeRepeating("DamageFlash", 0, Flashtime);
    }*/
    private void DamageUnFlash()
    {
        SkinnedMeshRenderer mesh = gameobject.GetComponent<SkinnedMeshRenderer>();
        mesh.enabled = true;
    }
    private void DamageFlash()
    {
        SkinnedMeshRenderer mesh = gameobject.GetComponent<SkinnedMeshRenderer>();
        mesh.enabled = false;
        Invoke("DamageUnFlash", Flashtime);
    }
}


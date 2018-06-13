using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {


 
    [SerializeField]
    private Animator Anim;
    

    public void Refresh(bool valor, string nombre)
    {
        Debug.Log(nombre + valor.ToString());
        Anim.SetBool(nombre, valor);
    }
   
	
	public void PlayAnim(string anim)
    {
        Anim.Play(anim);
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {


 
    [SerializeField]
    private Animator Anim;

    public void Refresh(int Arms, int Legs)
    {
        Anim.SetInteger("Arms", Arms);
        Anim.SetInteger("Legs", Legs);
    }
    public void Refresh(int Legs)
    {
        Anim.SetInteger("Legs", Legs);
    }
	
	public void PlayAnim(string anim)
    {
        Anim.Play(anim);
    }
	
}

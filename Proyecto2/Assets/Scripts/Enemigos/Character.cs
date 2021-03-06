﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    protected Vector3 Front;
    [SerializeField]
    protected int MaxHP;
    [SerializeField]
    protected int HP;
    [SerializeField]
    private float BlinkTime;
  
    protected AudioSource soundQueue;
    [SerializeField]
    protected GameObject SFXondeath;
   // [SerializeField]
   // private Color DefaultC;
   /* private int estadoDeBrazos;
    private int estadoDePiernas;

    public int EstadoDeBrazos()
    {
        return estadoDeBrazos;
    }
    public int EstadoDePiernas()
    {
        return estadoDePiernas;
    }
    public void CambiaEstadoDeBrazos(int Estado)
    {
        estadoDeBrazos = Estado;
    }
    public void CambiaEstadoDePiernas(int Estado)
    {
        estadoDePiernas = Estado;
    }
    */
    protected virtual void VisualQueue()
    {
       // GetComponent<MeshRenderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.white);
        //Invoke("BackToDefaultMat", BlinkTime);
    }
    private void BackToDefaultMat()
    {
      //  GetComponent<MeshRenderer>().material.SetColor(Shader.PropertyToID("_Color"), DefaultC);
    }
    protected virtual void  SoundQueue()
    {
        soundQueue.Play();
    }

    public virtual void  GetDamaged(int Damage)
    {
        SoundQueue();
        VisualQueue();
        HP -= Damage;
        if (HP <= 0) Death();
    }
  
    public void Heal(int Heal)
    {
        HP += Heal;
        if (HP > MaxHP) HP = MaxHP;
    }
    protected virtual void Death()
    {
        Instantiate(SFXondeath, transform.position, transform.rotation);
        //cosas que pasan cuando muere aca
    }
    protected virtual void StuffToDoOnAwake()
    {
        soundQueue = GetComponent<AudioSource>();
        HP = MaxHP;
    }
   public void Awake()
    {
        StuffToDoOnAwake();
    }
}

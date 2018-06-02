using System.Collections;
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
    [SerializeField]
    private Color DefaultC;


    protected virtual void VisualQueue()
    {
        GetComponent<MeshRenderer>().material.SetColor(Shader.PropertyToID("_Color"), Color.white);
        Invoke("BackToDefaultMat", BlinkTime);
    }
    private void BackToDefaultMat()
    {
        GetComponent<MeshRenderer>().material.SetColor(Shader.PropertyToID("_Color"), DefaultC);
    }

    public virtual void  GetDamaged(int Damage)
    {
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
        //cosas que pasan cuando muere aca
    }
    protected virtual void StuffToDoOnAwake()
    {
        HP = MaxHP;
    }
}

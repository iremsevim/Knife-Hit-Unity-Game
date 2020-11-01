using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelAnim_Movement : LevelAnimationBase
{
    public Vector3 pos;
    public float movemenyspeed;
    public bool IsMovement = false;

    private void Start()
    {
       if(IsMovement)
        {
            PlayAnim();
        }
    }
    public override void PlayAnim()
    {
        base.PlayAnim();
        transform.DOMove(transform.position + pos, movemenyspeed);
       
    }



  
}

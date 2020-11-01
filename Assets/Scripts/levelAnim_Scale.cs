using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class levelAnim_Scale : LevelAnimationBase
{
    public bool ısActive = false;
  
    public float scaleduration = 0.5f;
    public float scaleamount = 2f;
    public Vector3 startscale;

    public void Awake()
    {
        startscale = transform.localScale;
    }

    private void Start()
    {

        if(ısActive)
        {
            PlayAnim();
        }
    }
    public override void PlayAnim()
    {
        base.PlayAnim();
        transform.DOScale(scaleamount, scaleduration).OnComplete(() =>
        {
            transform.DOScale(startscale, scaleduration);
        });
      
    }
    

  
}

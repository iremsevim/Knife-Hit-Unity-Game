using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateCircleController : MonoBehaviour
{
    public static RotateCircleController live;
    public float rotatespeed;

    public string collisionaudio;
    public List<GameObject> allknifelist;
    public Sprite newsprite;
    public int knifeorder = 0;
    public float shakeduration = 0.5f;
    public float timer = 3f;

    public float timerduration=3f;
    public RotateType rotateType;
    public List<KnifeController> knifes;
    public List<GameObject> applepoints;
    public GameObject appleprefab;


    public void Awake()
    {
        live = this;
       
    }


    void Start()
    {
        CreateİnCircleObject();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            if (rotateType == RotateType.left)
            {
                rotateType = RotateType.right;
            }
            else
            {
                rotateType = RotateType.left;
            }
            timer = timerduration;
        }
       

        if(rotateType==RotateType.right)
        {
            transform.Rotate(0, 0, 30*rotatespeed*Time.deltaTime);
        }
        else if(rotateType==RotateType.left)
        {
            transform.Rotate(0, 0, -30*rotatespeed*Time.deltaTime);
        }
     
        
     }
    public void CreateİnCircleObject()
    {
        bool IsCreate = false;
        for (int i = 0; i < applepoints.Count; i++)
        {
            if (Random.Range(2, 10) < 5)
            {
                IsCreate = true;
                GameObject createobject = Instantiate(appleprefab, applepoints[i].transform.position, Quaternion.identity);
                createobject.transform.SetParent(transform);

            }
        }
        if (!IsCreate)
        {
            int randomnewpoint = Random.Range(0, applepoints.Count);
            GameObject createoneobject = Instantiate(appleprefab,applepoints[randomnewpoint].transform.position, Quaternion.identity);
        }
          
    }
     
       
      
       
        
      
      
    
    public void OnTriggerEnter2D(Collider2D other)

    {



        if (other.tag=="knife")
        
        {
            GameManager.live.IsStarted = true;

            knifes.Add(other.GetComponent<KnifeController>());
            Debug.Log("çarptı");
            
            transform.DOShakePosition(shakeduration);
           
            
            AudioManager.live.CreateAudio(collisionaudio);
            for (int i =knifeorder; i < allknifelist.Count; i++)
            {
                allknifelist[i].GetComponent<SpriteRenderer>().sprite = newsprite;
                knifeorder++;
                break;
            }
            if(knifeorder==allknifelist.Count)
            {
                GameManager.live.ısComplate = true;
                GameManager.live.GameOver();
            }
          
        }
       


    }
    

    public enum RotateType
    {
        right=0,left=1
    }

    
}

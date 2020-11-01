using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager live;
    public GameObject knifeprefab;
    public Transform knifespawnpoint;
    public float speed;
    public bool IsContinue = true;
    public List<GameObject> sprites;
    public bool IsStarted = false;
    public int nextlevelindex;
    public int ownlevelindex;
    public bool ısComplate = false;

    void Awake()
    {
        live = this;
    }
    void Start()
    {
        IsStarted = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsContinue) return;
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateKnife();
        }
    }
    public void CreateKnife()
    {
        if(IsStarted)
        {
            GameObject createknife = Instantiate(knifeprefab, knifespawnpoint.position, Quaternion.identity);
            createknife.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            IsStarted = false;
        }
    }
    public void GameOver()
    {


        Bonus.DestroyBonus();
       
        IsContinue = false;
        RotateCircleController.live.rotatespeed = 0f;

        RotateCircleController.live.GetComponent<SpriteRenderer>().sprite = null;
        

       
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].SetActive(true);
          Vector3 explosionright=-sprites[i].transform.right + sprites[i].transform.up;
            Vector3 explosionleft = sprites[i].transform.right - sprites[i].transform.up;

            int explosıonamount = Random.Range(350, 600);
            if(Random.Range(2,8)<5)
            {

                sprites[i].GetComponent<Rigidbody2D>().AddForce(explosionright * explosıonamount);
            }
            else
            {
                sprites[i].GetComponent<Rigidbody2D>().AddForce(explosionleft * explosıonamount);
            }
           
        }
          RotateCircleController.live.knifes.ForEach(x => x.KinfesForce());
        //KnifeController.DestroyAllKnife();
        StartCoroutine(SceneLoadTimer());
        Debug.Log("oyun bitti");
    }
    public IEnumerator SceneLoadTimer()
    {
       if(ısComplate)
        {
            yield return new WaitForSeconds(2f);
            LevelManager.instance.LoadScene(nextlevelindex);
        }
       else
        {
            yield return new WaitForSeconds(2f);
            LevelManager.instance.LoadScene(ownlevelindex);
        }
       


    }


}

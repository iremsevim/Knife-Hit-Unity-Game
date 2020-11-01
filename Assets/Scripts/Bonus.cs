using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public static List<Bonus> bonuslist = new List<Bonus>();
    
    public Rigidbody2D rb;
    public List<GameObject> aplleprefabs;

    
    void Awake()
    {
        bonuslist.Add(this);
    }
    void OnDestroy()
    {
        bonuslist.Remove(this);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void ExplosionBonus()
    {

        aplleprefabs.ForEach(x => { 
            x.gameObject.SetActive(true);


            x.GetComponent<Rigidbody2D>().freezeRotation = false;
            x.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            x.transform.SetParent(null);
            x.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(500f, 700f);
            x.GetComponent<Rigidbody2D>().gravityScale = 1;
            x.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector3 force =Vector3.up * Random.Range(200f, 400f);

            x.GetComponent<Rigidbody2D>().AddForce(force);
        }   
        );
        Destroy(this.gameObject);
    }
   
    public static void DestroyBonus()
    {
        GameManager.live.StartCoroutine(TimerDestroy());
    }

    private static IEnumerator TimerDestroy()
    {
        for (int i = 0; i < bonuslist.Count; i++)
        {
            bonuslist[i].gameObject.SetActive(false);
      
            yield return new WaitForSeconds(0.4f);
        }
    }
}

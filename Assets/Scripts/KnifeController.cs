using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public static List<KnifeController> knifelists = new List<KnifeController>();
    public static KnifeController instance;
    public Rigidbody2D rb;
    public float speed;
    public BoxCollider2D collider2D;
   
    void Awake()
    {
        instance = this;
        knifelists.Add(this);
    }

    void OnDestroy()
    {
        knifelists.Remove(this);
    }
  
       void Start()
     {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
     }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "circle")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(RotateCircleController.live.transform);
            //collider2D.offset = new Vector2(collider2D.offset.x, -1.17f);
            //collider2D.size = new Vector2(collider2D.size.x, 2.07f); 
        }
        else if(other.GetComponent<KnifeController>())
        {
            Debug.Log("Bıçak");
            GameManager.live.GameOver();
        }
        else if(other.GetComponent<Bonus>())
        {
            other.GetComponent<Bonus>().ExplosionBonus();
        }


    }

    public void KinfesForce()
    {
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints2D.None;
        transform.SetParent(null);
        rb.angularVelocity = Random.Range(500f, 700f);
        rb.gravityScale = 1;
        rb.bodyType = RigidbodyType2D.Dynamic;
        Vector3 force = transform.up*Random.Range(200f,300f);
       
        rb.AddForce(force);
    }

    public static void DestroyAllKnife()
    {
       
        GameManager.live.StartCoroutine(TimerDestroy());
      
    }
   
    public static IEnumerator TimerDestroy()
    {
        yield return new WaitForSeconds(2f);
        knifelists.ForEach(x => x.gameObject.SetActive(false));

    }


}

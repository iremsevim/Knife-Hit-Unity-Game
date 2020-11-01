using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float rotatespeed;
    public float timer = 3f;
    public float timerduration = 3f;
  

    bool right = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            right = !right;
            timer = timerduration;
        }

        if (right)
        {
            transform.Rotate(0, 0, -30 * Time.deltaTime * rotatespeed);
        }
        else
        {
            transform.Rotate(0, 0, 30 * Time.deltaTime * rotatespeed);
        }
    }
}

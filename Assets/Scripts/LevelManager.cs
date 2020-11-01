using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            if (instance!=this)
            {
                Destroy(gameObject);
            }
           
        }
    }

    public void LoadScene(int builtindex) 
    {
        SceneManager.LoadScene(builtindex);
    }

}

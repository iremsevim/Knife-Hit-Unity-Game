using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_Listener : MonoBehaviour
{
   

    public void ButonEvents(int index)
    {
        switch(index)
        {
            case 0:
                LevelManager.instance.LoadScene(1);

            break;
            case 1:
                LevelManager.instance.LoadScene(2);
                break;
            case 3:
                LevelManager.instance.LoadScene(3);
                break;
        }
    }
}

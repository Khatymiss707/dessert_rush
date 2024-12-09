using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    public GameObject panel;
    public void Trigger()
    {
        if (panel.activeInHierarchy == false)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
        
    }

}

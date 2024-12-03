using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mochi_chocolat : MonoBehaviour
{
    public GameObject fraise;
    public GameObject mangues;
    public GameObject chocolat;
    public GameObject matcha;
    public Transform spawnPoint;


    public void apparition()
    {
        Instantiate(chocolat, spawnPoint);
    }

    public void apparitionMangues()
    {
        Instantiate(mangues, spawnPoint);


    }        
    
    public void apparitionfraise()
        {
            Instantiate(fraise, spawnPoint);
        }

    public void apparitionMatcha()
    {
        Instantiate(matcha, spawnPoint);
    }
}

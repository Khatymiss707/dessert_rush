using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validation_commande : MonoBehaviour
{
    public control script;
    public GameObject fraise;
    public GameObject mangues;
    public GameObject chocolat;
    public GameObject matcha;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == script.client_actuel.tag)
        {
            script.reussite();
            fraise.SetActive(false);
            mangues.SetActive(false);
            chocolat.SetActive(false);
            matcha.SetActive(false);
        }
        else { 
            script.failure();
            fraise.SetActive(false);
            mangues.SetActive(false);
            chocolat.SetActive(false);
            matcha.SetActive(false);
        }
    }
}

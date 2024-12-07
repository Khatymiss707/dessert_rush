using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validation_commande : MonoBehaviour
{
    public control script;
    public GameObject fraise;
    public GameObject vanille;
    public GameObject chocolat;
    public GameObject matcha;

    public IEnumerator mochi_despawn()
    {
        yield return new WaitForSeconds(3);
        fraise.SetActive(false);
        chocolat.SetActive(false);
        vanille.SetActive(false);
        matcha.SetActive(false);
        yield break;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == script.client_actuel.tag)
        {
            script.reussite();
            StartCoroutine("mochi_despawn");
        }
        else { 
            script.failure();
            StartCoroutine("mochi_despawn");
        }
    }
}

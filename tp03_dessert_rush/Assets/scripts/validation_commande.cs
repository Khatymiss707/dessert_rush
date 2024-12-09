using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validation_commande : MonoBehaviour
{
    public control script;


    public IEnumerator mochi_despawn(GameObject mochi)
    {
        yield return new WaitForSeconds(3);
        Destroy(mochi);
        yield break;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == script.client_actuel.tag)
        {
            script.reussite();
            StartCoroutine("mochi_despawn", other.gameObject);
        }
        else { 
            script.failure();
            StartCoroutine("mochi_despawn", other.gameObject);

        }
    }
}

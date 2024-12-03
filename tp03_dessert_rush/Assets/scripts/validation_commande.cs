using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validation_commande : MonoBehaviour
{
    public control script;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == script.client_actuel.tag)
        {
            script.reussite();
        }
        else { script.failure();
        }
    }
}

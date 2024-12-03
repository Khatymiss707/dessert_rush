using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordre : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject marche;
    public GameObject ordering;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "command")
        {
            marche.SetActive(false);
            ordering.SetActive(true);
        }
    }
}
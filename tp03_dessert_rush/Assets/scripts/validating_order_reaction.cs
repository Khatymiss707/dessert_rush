using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validating_order_reaction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject valid;
    public GameObject invalid;
    public GameObject request;
    public GameObject ordering;
    public GameObject commande;

    void Start() // Add a Start method where the code logic should go
    {
        if (request == commande) // Fix the if condition
        {
            ordering.SetActive(false);
            valid.SetActive(true);
        }
        else // Simplified else statement, no need for 'else if' here
        {
            ordering.SetActive(false);
            invalid.SetActive(true);
        }
    }
}

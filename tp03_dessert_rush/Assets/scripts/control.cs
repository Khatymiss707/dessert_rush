using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject[] client;
    public GameObject client_actuel;

    private void Start()
    {
        StartCoroutine("first_client");
    }

    public IEnumerator first_client() 
    {
        yield return new WaitForSeconds(8);
        int xcount = Random.Range(1, 5);
        client_actuel = client[xcount];
        client[xcount].GetComponent<Animator>().Play("comming");
        yield break;
    }

    public void reussite()
    {
        client_actuel.GetComponent<Animator>().Play("fuck off");
        StartCoroutine("first_client");


    } 
    public void failure()
    {
        client_actuel.GetComponent<Animator>().Play("fuck off");
        StartCoroutine("first_client");


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    // Store the clients (models) in the array
    public GameObject[] client; // All models with various expressions and colors
    public GameObject client_actuel; // The currently active client

    private void Start()
    {
        StartCoroutine("first_client");
    }

    public IEnumerator first_client() 
    {
        yield return new WaitForSeconds(8);  // Wait for 8 seconds before selecting the first client

        // Randomly select a client from the array
        int xcount = Random.Range(0, client.Length); // Ensure it fits the range of your array
        client_actuel = client[xcount];  // Assign the selected model

        // Disable all other clients to ensure only one plays animation
        DisableAllClients();

        // Play the "marche_entree" animation for the selected model
        Animator currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("marche_entree");

        // After marche_entree finishes, play "ordering"
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until the first animation is done
        currentAnimator.Play("ordering");

        yield break;
    }

    // Method to disable all other clients' models to ensure only the active one is visible
    private void DisableAllClients()
    {
        foreach (GameObject c in client)
        {
            if (c != client_actuel)  // Only disable models that are not the current one
            {
                c.SetActive(false);
            }
        }
    }

    public void reussite()
    {
        // When a success occurs, play success animations for the active client
        Animator currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("happy_jump");
        currentAnimator.Play("tourne");
        currentAnimator.Play("leaving");

        // Start the process again by selecting a new client after the animations
        StartCoroutine("first_client");
    } 

    public void failure()
    {
        // When a failure occurs, play failure animations for the active client
        Animator currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("not_happy");
        currentAnimator.Play("tourne");
        currentAnimator.Play("leaving");

        // Start the process again by selecting a new client after the animations
        StartCoroutine("first_client");
    }
}


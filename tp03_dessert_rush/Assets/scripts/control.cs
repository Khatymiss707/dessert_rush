using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    // Store the client models (with different colors)
    public GameObject[] client; // All models with various expressions and colors
    public GameObject client_actuel; // The currently active client

    private void Start()
    {
        StartCoroutine("first_client");
    }

    public IEnumerator first_client()
    {
        yield return new WaitForSeconds(8);  // Wait for 8 seconds before selecting the first client

        // Randomly select a client (color model) from the array (0 to 3 for 4 different colors)
        int xcount = Random.Range(0, 4); // Randomly pick a model from 0 to 3 (4 different colors)
        client_actuel = client[xcount];  // Assign the selected model

        // Disable all other clients to ensure only one plays animation
        DisableAllClients();

        // Get the Animator component of the selected client
        Animator currentAnimator = client_actuel.GetComponent<Animator>();

        // Play the "marche_entree" animation for the selected client
        currentAnimator.Play("marche_entree");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until the animation finishes

        // Now play the "ordering" animation for the selected client
        currentAnimator.Play("ordering");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until the animation finishes

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
        // Success path: Play success animations and transition to the Happy model
        Animator currentAnimator = client_actuel.GetComponent<Animator>();

        // Hide the current model (Neutral or Ordering)
        client_actuel.SetActive(false);

        // Find and activate the Happy model
        foreach (GameObject c in client)
        {
            if (c.CompareTag("Happy"))
            {
                client_actuel = c;  // Set the new Happy model
                client_actuel.SetActive(true);  // Show Happy model
                break;
            }
        }

        // Play happy success animation
        currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("happy_jump");

        // Play other success animations
        currentAnimator.Play("tourne");
        currentAnimator.Play("leaving");

        // Continue with the sequence
        StartCoroutine("first_client");
    }

    public void failure()
    {
        // Failure path: Same logic as reussite but with the "mad" animation for failure
        Animator currentAnimator = client_actuel.GetComponent<Animator>();

        // Hide the current model (Neutral or Ordering)
        client_actuel.SetActive(false);

        // Find and activate the Mad model
        foreach (GameObject c in client)
        {
            if (c.CompareTag("Mad"))
            {
                client_actuel = c;  // Set the new Mad model
                client_actuel.SetActive(true);  // Show Mad model
                break;
            }
        }

        // Play the "mad" animation for failure
        currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("mad");  // Play the "mad" animation (for failure)

        // Play other failure animations
        currentAnimator.Play("tourne");
        currentAnimator.Play("leaving");

        // Continue with the sequence
        StartCoroutine("first_client");
    }
}


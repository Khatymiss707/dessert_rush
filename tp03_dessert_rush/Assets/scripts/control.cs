using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    // Store the client models (with different colors and states)
    public GameObject[] clientNeutral; // All neutral models (marche_entree)
    public GameObject[] clientOrdering; // All ordering models (ordering)
    public GameObject[] clientHappy; // All happy models
    public GameObject[] clientMad; // All mad models

    public GameObject client_actuel; // The currently active client model (neutral, ordering, happy, or mad)

    private void Start()
    {
        StartCoroutine("first_client");
    }

    public IEnumerator first_client()
    {
        yield return new WaitForSeconds(8);  // Wait for 8 seconds before selecting the first client

        // Randomly select a client (color model) from the array (0 to 3 for 4 different colors)
        int xcount = Random.Range(0, 4); // Randomly pick a model from 0 to 3 (4 different colors)

        // Start with the Neutral model (marche_entree animation)
        client_actuel = clientNeutral[xcount];  // Assign the selected neutral model
        client_actuel.SetActive(true);  // Enable the neutral model

        // Disable all other clients to ensure only one plays animation
        DisableAllClientsExcept(client_actuel);

        // Get the Animator component of the selected client
        Animator currentAnimator = client_actuel.GetComponent<Animator>();

        // Play the "marche_entree" animation for the selected neutral model
        currentAnimator.Play("marche_entree");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until the animation finishes

        // After "marche_entree", replace the neutral model with the ordering model
        client_actuel.SetActive(false);  // Hide the neutral model

        // Now activate the Ordering model (play "ordering" animation)
        client_actuel = clientOrdering[xcount];  // Select the corresponding ordering model
        client_actuel.SetActive(true);  // Enable the ordering model

        // Play the "ordering" animation for the selected ordering model
        currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("ordering");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until the animation finishes

        yield break;
    }

    // Method to disable all other clients' models except the currently active one
    private void DisableAllClientsExcept(GameObject activeClient)
    {
        foreach (GameObject c in clientNeutral)
        {
            if (c != activeClient)  // Only disable models that are not the current one
            {
                c.SetActive(false);
            }
        }

        foreach (GameObject c in clientOrdering)
        {
            if (c != activeClient)  // Only disable models that are not the current one
            {
                c.SetActive(false);
            }
        }

        foreach (GameObject c in clientHappy)
        {
            c.SetActive(false);
        }

        foreach (GameObject c in clientMad)
        {
            c.SetActive(false);
        }
    }

    public IEnumerator reussite()
    {
        // Success path: Transition to Happy model and play success animations
        Animator currentAnimator = client_actuel.GetComponent<Animator>();

        // Hide the current model (Neutral or Ordering)
        client_actuel.SetActive(false);

        // Find and activate the Happy model
        int xcount = GetColorIndexFromClient(client_actuel);
        client_actuel = clientHappy[xcount];  // Set the new Happy model
        client_actuel.SetActive(true);  // Show Happy model

        // Play happy success animation
        currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("happy_jump");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until animation finishes

        // Play "tourne" and "leaving" animations sequentially
        currentAnimator.Play("tourne");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);

        currentAnimator.Play("leaving");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Continue with the sequence
        StartCoroutine("first_client");
    }

    public IEnumerator failure()
    {
        // Failure path: Transition to Mad model and play failure animations
        Animator currentAnimator = client_actuel.GetComponent<Animator>();

        // Hide the current model (Neutral or Ordering)
        client_actuel.SetActive(false);

        // Find and activate the Mad model
        int xcount = GetColorIndexFromClient(client_actuel);
        client_actuel = clientMad[xcount];  // Set the new Mad model
        client_actuel.SetActive(true);  // Show Mad model

        // Play the "mad" animation for failure
        currentAnimator = client_actuel.GetComponent<Animator>();
        currentAnimator.Play("mad");  // Play the "mad" animation (for failure)
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);  // Wait until animation finishes

        // Play "tourne" and "leaving" animations sequentially
        currentAnimator.Play("tourne");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);

        currentAnimator.Play("leaving");
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Continue with the sequence
        StartCoroutine("first_client");
    }


    // Helper method to get the index of the color model
    private int GetColorIndexFromClient(GameObject client)
    {
        for (int i = 0; i < 4; i++)
        {
            if (client == clientNeutral[i] || client == clientOrdering[i] || client == clientHappy[i] || client == clientMad[i])
            {
                return i;
            }
        }
        return -1;  // Default fallback
    }
}


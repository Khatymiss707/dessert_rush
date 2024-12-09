using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class validation_commande : MonoBehaviour
{
    public control script;
    public int count_yes;
    public int count_no;
    public int count;
    public TextMeshProUGUI total;
    public TextMeshProUGUI succes;
    public TextMeshProUGUI fail;
    public GameObject fin;
    public IEnumerator mochi_despawn(GameObject mochi)
    {
        yield return new WaitForSeconds(3);
        Destroy(mochi);
        yield break;
    }

    public void OnTriggerEnter(Collider other)
    {
        count++;
        total.text = count.ToString();
        if(count < 10) { 
        if(other.tag == script.client_actuel.tag)
        {
            script.reussite();
            StartCoroutine("mochi_despawn", other.gameObject);
            count_yes++;
            succes.text = count_yes.ToString();

        }
        else { 
            script.failure();
            StartCoroutine("mochi_despawn", other.gameObject);
            count_no++;
            fail.text = count_no.ToString();

        }
    }else if(count == 10)
        {
            fin.SetActive(true);
        }
   }
}

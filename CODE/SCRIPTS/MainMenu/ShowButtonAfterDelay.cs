using System.Collections;
using UnityEngine;

public class ShowButtonAfterDelay : MonoBehaviour
{
    public GameObject buttonToShow;
    public float delay = 0.5f; // Aspettiamo 2 secondi

    void Start()
    {
        buttonToShow.SetActive(true); // All'inizio nascondiamo il bottone
        //StartCoroutine(ShowButton());
    }

    // IEnumerator ShowButton()
    // {
    //     yield return new WaitForSeconds(delay);
    //     buttonToShow.SetActive(true); // Dopo il delay mostriamo il bottone
    // }
}

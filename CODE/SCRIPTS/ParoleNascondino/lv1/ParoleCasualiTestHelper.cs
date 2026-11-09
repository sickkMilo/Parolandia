using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParoleCasualiTestHelper : MonoBehaviour
{
    [Header("Riferimenti Manager")]
    public ParoleCasualiManager manager;

    void Start()
    {
        if (manager == null)
        {
            Debug.LogError("ParoleCasualiManager non assegnato.");
            return;
        }

        TestUIReferences();
        TestSlots();
        TestLettereGenerate();
        TestAudio();
    }

    // Verifica che i riferimenti UI principali siano assegnati
    void TestUIReferences()
    {
        if (manager.verificaButton == null)
            Debug.LogError("VerificaButton non assegnato.");
        else
            Debug.Log("VerificaButton OK.");

        if (manager.counterText == null)
            Debug.LogError("CounterText non assegnato.");
        else
            Debug.Log("CounterText OK.");

        if (manager.feedbackPanel == null)
            Debug.LogError("FeedbackPanel non assegnato.");
        else
            Debug.Log("FeedbackPanel OK.");

        if (manager.livelloCompletatoPanel == null)
            Debug.LogError("LivelloCompletatoPanel non assegnato.");
        else
            Debug.Log("LivelloCompletatoPanel OK.");
    }

    // Verifica che gli slot delle lettere siano presenti
    void TestSlots()
    {
        if (manager.slotImages == null || manager.slotImages.Length == 0)
        {
            Debug.LogError("Nessuno slot di inserimento lettere trovato.");
        }
        else
        {
            Debug.Log("Numero slot trovati: " + manager.slotImages.Length);
        }
    }

    // Controlla se le lettere sono state generate all’avvio
    void TestLettereGenerate()
    {
        int lettere = GameObject.FindGameObjectsWithTag("Lettera").Length;
        if (lettere == 0)
        {
            Debug.LogWarning("Nessuna lettera trovata in scena (verifica prefab/tag).");
        }
        else
        {
            Debug.Log("Lettere attive in scena: " + lettere);
        }
    }

    // Verifica presenza e stato dell’AudioSource
    void TestAudio()
    {
        AudioSource audio = manager.GetComponent<AudioSource>();
        if (audio == null)
            Debug.LogWarning("AudioSource non presente nel manager.");
        else
            Debug.Log("AudioSource trovato nel manager.");
    }
}

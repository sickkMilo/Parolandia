using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EcoGiocoTestHelper : MonoBehaviour
{
    [Header("Manager")]
    public EcoGiocoManager ecoGiocoManager;

    void Start()
    {
        if (ecoGiocoManager == null)
        {
            Debug.LogError("EcoGiocoManager non assegnato.");
            return;
        }

        TestUIRiferimenti();
        TestAudioClip();
        TestBottoniRisposta();
    }

    // Verifica la presenza degli elementi UI principali
    void TestUIRiferimenti()
    {
        if (ecoGiocoManager.playButton == null)
            Debug.LogError("playButton non assegnato.");
        else
            Debug.Log("playButton OK.");

        if (ecoGiocoManager.counterText == null)
            Debug.LogError("counterText non assegnato.");
        else
            Debug.Log("counterText OK.");

        if (ecoGiocoManager.feedbackPanel == null)
            Debug.LogError("feedbackPanel non assegnato.");
        else
            Debug.Log("feedbackPanel OK.");
    }

    // Verifica che sia caricato correttamente un AudioClip della parola da riprodurre
    void TestAudioClip()
    {
        AudioSource audio = ecoGiocoManager.audioSource;
        if (audio == null)
        {
            Debug.LogError("AudioSource non assegnato.");
            return;
        }

        Debug.Log("AudioSource OK.");

        if (ecoGiocoManager.suonoCorretto == null)
            Debug.LogWarning("suonoCorretto non assegnato.");
        else
            Debug.Log("suonoCorretto OK.");

        if (ecoGiocoManager.suonoErrato == null)
            Debug.LogWarning("suonoErrato non assegnato.");
        else
            Debug.Log("suonoErrato OK.");
    }

    // Controlla che i bottoni delle parole siano generati correttamente
    void TestBottoniRisposta()
    {
        int count = ecoGiocoManager.buttonsContainer.childCount;
        if (count == 0)
        {
            Debug.LogWarning("Nessun bottone risposta trovato all'avvio.");
        }
        else
        {
            Debug.Log("Bottoni risposta trovati nel container: " + count);
        }
    }
}

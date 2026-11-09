using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SfidaMemoTestHelper : MonoBehaviour
{
    [Header("Manager")]
    public SfidaMemoManager sfidaMemoManager;

    void Start()
    {
        if (sfidaMemoManager == null)
        {
            Debug.LogError("SfidaMemoManager non assegnato nel TestHelper.");
            return;
        }

        TestUIRiferimenti();
        TestContainerBottoni();
        TestAudio();
    }

    // Verifica che i riferimenti UI principali siano assegnati
    void TestUIRiferimenti()
    {
        if (sfidaMemoManager.imageDisplay == null)
            Debug.LogError("imageDisplay non assegnato.");
        else
            Debug.Log("imageDisplay OK.");

        if (sfidaMemoManager.counterText == null)
            Debug.LogError("counterText non assegnato.");
        else
            Debug.Log("counterText OK.");

        if (sfidaMemoManager.feedbackPanel == null)
            Debug.LogError("feedbackPanel non assegnato.");
        else
            Debug.Log("feedbackPanel OK.");

        if (sfidaMemoManager.feedbackText == null)
            Debug.LogError("feedbackText non assegnato.");
        else
            Debug.Log("feedbackText OK.");

        if (sfidaMemoManager.livelloCompletatoPanel == null)
            Debug.LogError("livelloCompletatoPanel non assegnato.");
        else
            Debug.Log("livelloCompletatoPanel OK.");
    }

    // Verifica se i bottoni generati sono presenti nel container
    void TestContainerBottoni()
    {
        if (sfidaMemoManager.buttonsContainer == null)
        {
            Debug.LogError("buttonsContainer non assegnato.");
            return;
        }

        int bottoneCount = sfidaMemoManager.buttonsContainer.childCount;
        Debug.Log("Bottoni trovati nel container: " + bottoneCount);
    }

    // Verifica se l’audio e i clip di feedback sono presenti
    void TestAudio()
    {
        if (sfidaMemoManager.audioSource == null)
        {
            Debug.LogWarning("AudioSource non assegnato.");
            return;
        }

        Debug.Log("AudioSource OK.");

        if (sfidaMemoManager.suonoCorretto == null)
            Debug.LogWarning("suonoCorretto non assegnato.");
        else
            Debug.Log("suonoCorretto OK.");

        if (sfidaMemoManager.suonoErrato == null)
            Debug.LogWarning("suonoErrato non assegnato.");
        else
            Debug.Log("suonoErrato OK.");
    }
}

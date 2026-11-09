using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrovaTrovaTestHelper : MonoBehaviour
{
    [Header("Manager")]
    public MonoBehaviour trovaTrovaManager;

    void Start()
    {
        if (trovaTrovaManager == null)
        {
            Debug.LogError("TrovaTrovaManager non assegnato.");
            return;
        }

        TestComponentiUI();
        TestContainerBottoni();
        TestAudioFeedback();
    }

    // Verifica che i componenti visivi principali siano presenti
    void TestComponentiUI()
    {
        Image imageBox = trovaTrovaManager.GetType().GetField("imageBox").GetValue(trovaTrovaManager) as Image;
        if (imageBox == null)
            Debug.LogError("imageBox non assegnato.");
        else
            Debug.Log("imageBox OK.");

        TextMeshProUGUI counterText = trovaTrovaManager.GetType().GetField("counterText").GetValue(trovaTrovaManager) as TextMeshProUGUI;
        if (counterText == null)
            Debug.LogError("counterText non assegnato.");
        else
            Debug.Log("counterText OK.");

        GameObject feedbackPanel = trovaTrovaManager.GetType().GetField("feedbackPanel").GetValue(trovaTrovaManager) as GameObject;
        if (feedbackPanel == null)
            Debug.LogError("feedbackPanel non assegnato.");
        else
            Debug.Log("feedbackPanel OK.");
    }

    // Verifica se il container dei bottoni è presente e contiene figli
    void TestContainerBottoni()
    {
        Transform buttonsContainer = trovaTrovaManager.GetType().GetField("buttonsContainer").GetValue(trovaTrovaManager) as Transform;
        if (buttonsContainer == null)
        {
            Debug.LogError("buttonsContainer non assegnato.");
            return;
        }

        int figli = buttonsContainer.childCount;
        Debug.Log("Bottoni trovati nel container: " + figli);
        if (figli == 0)
            Debug.LogWarning("Nessun bottone presente nel container all’avvio.");
    }

    // Controlla che l'audio e le clip di feedback siano assegnate
    void TestAudioFeedback()
    {
        AudioSource audioSource = trovaTrovaManager.GetType().GetField("audioSource").GetValue(trovaTrovaManager) as AudioSource;
        if (audioSource == null)
            Debug.LogWarning("AudioSource mancante.");
        else
            Debug.Log("AudioSource presente.");

        AudioClip clipCorretto = trovaTrovaManager.GetType().GetField("suonoCorretto").GetValue(trovaTrovaManager) as AudioClip;
        AudioClip clipErrato = trovaTrovaManager.GetType().GetField("suonoErrato").GetValue(trovaTrovaManager) as AudioClip;

        if (clipCorretto == null) Debug.LogWarning("suonoCorretto non assegnato.");
        else Debug.Log("suonoCorretto OK.");

        if (clipErrato == null) Debug.LogWarning("suonoErrato non assegnato.");
        else Debug.Log("suonoErrato OK.");
    }
}

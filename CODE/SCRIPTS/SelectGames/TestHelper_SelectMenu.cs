using UnityEngine;
using UnityEngine.UI;

public class TestHelper_SelectMenu : MonoBehaviour
{
    [Header("Bottoni minigiochi")]
    public Button paroleNascondinoButton;
    public Button trovaTrovaButton;
    public Button ecoGiocoButton;
    public Button sfidaMemoButton;

    [Header("Impostazioni")]
    public GameObject settingsPanel;
    public Button settingsButton;
    public Button musicToggleButton;
    public Button guideButton;
    public Button exitButton;
    public Button closeSettingsButton;

    void Start()
    {
        TestBottoniGiochi();
        TestImpostazioni();
    }

    // Verifica la presenza dei bottoni per ciascun minigioco
    void TestBottoniGiochi()
    {
        if (paroleNascondinoButton == null)
            Debug.LogError("ParoleNascondinoButton non assegnato.");
        else
            Debug.Log("ParoleNascondinoButton OK.");

        if (trovaTrovaButton == null)
            Debug.LogError("TrovaTrovaButton non assegnato.");
        else
            Debug.Log("TrovaTrovaButton OK.");

        if (ecoGiocoButton == null)
            Debug.LogError("EcoGiocoButton non assegnato.");
        else
            Debug.Log("EcoGiocoButton OK.");

        if (sfidaMemoButton == null)
            Debug.LogError("SfidaMemoButton non assegnato.");
        else
            Debug.Log("SfidaMemoButton OK.");
    }

    // Verifica la configurazione del pannello impostazioni e dei relativi bottoni
    void TestImpostazioni()
    {
        if (settingsPanel == null)
            Debug.LogError("SettingsPanel non assegnato.");
        else
            Debug.Log("SettingsPanel OK.");

        if (settingsButton == null)
            Debug.LogError("SettingsButton non assegnato.");
        else
            Debug.Log("SettingsButton OK.");

        if (musicToggleButton == null)
            Debug.LogError("MusicToggleButton non assegnato.");
        else
            Debug.Log("MusicToggleButton OK.");

        if (guideButton == null)
            Debug.LogError("GuideButton non assegnato.");
        else
            Debug.Log("GuideButton OK.");

        if (exitButton == null)
            Debug.LogError("ExitButton non assegnato.");
        else
            Debug.Log("ExitButton OK.");

        if (closeSettingsButton == null)
            Debug.LogError("CloseSettingsButton non assegnato.");
        else
            Debug.Log("CloseSettingsButton OK.");
    }
}

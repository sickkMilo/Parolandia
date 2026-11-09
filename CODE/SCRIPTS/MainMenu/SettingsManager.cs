using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public GameObject settingsPanel;
    public Button musicToggleButton;
    public Button guideButton;
    public Button exitGameButton;
    public Button closeSettingsButton;

    private bool musicaAttiva = true;
    private MusicManager music;

    public GameObject guidaPanel;

    void Start()
    {
        music = TrovaMusicManager();
        settingsPanel.SetActive(false);

        musicToggleButton.onClick.AddListener(ToggleMusica);
        guideButton.onClick.AddListener(MostraGuida);
        exitGameButton.onClick.AddListener(EsciDalGioco);
        closeSettingsButton.onClick.AddListener(ChiudiPannello);

        // Carica lo stato della musica salvato
        musicaAttiva = PlayerPrefs.GetInt("musicaAttiva", 1) == 1;
        ApplicaStatoMusica();
    }

    MusicManager TrovaMusicManager()
    {
        GameObject mm = GameObject.Find("MusicManager");
        return mm?.GetComponent<MusicManager>();
    }

    public void ApriChiudiImpostazioni()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    void ToggleMusica()
    {
        musicaAttiva = !musicaAttiva;
        ApplicaStatoMusica();

        // Salva preferenza
        PlayerPrefs.SetInt("musicaAttiva", musicaAttiva ? 1 : 0);
        PlayerPrefs.Save();
    }

    void ApplicaStatoMusica()
    {
        if (musicaAttiva)
        {
            music?.RiattivaMusica();
        }
        else
        {
            music?.SpegniMusica();
        }
    }

    void MostraGuida()
    {
        guidaPanel.SetActive(true);
    }

    void EsciDalGioco()
    {
        Debug.Log("Uscita dal gioco");
        Application.Quit();
    }

    void ChiudiPannello()
    {
        settingsPanel.SetActive(false);
    }
}

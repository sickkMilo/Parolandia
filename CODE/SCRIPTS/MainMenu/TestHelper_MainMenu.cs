using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestHelper_MainMenu : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        Debug.Log("[TEST MENU] Avviato");

        TestStartButton();
        TestMusicManager();
    }

    void TestStartButton()
    {
        if (startButton == null)
        {
            Debug.LogError("StartButton non assegnato!");
        }
        else
        {
            Debug.Log("StartButton assegnato correttamente");
        }
    }

    void TestMusicManager()
    {
        MusicManager music = FindObjectOfType<MusicManager>();

        if (music == null)
        {
            Debug.LogWarning("MusicManager non trovato");
            return;
        }

        bool attiva = music.GetComponent<AudioSource>().isPlaying;
        Debug.Log(attiva ? "🎵 Musica attiva" : "Musica disattiva");

        int valSalvato = PlayerPrefs.GetInt("musicaAttiva", 1);
        Debug.Log("Stato salvato in PlayerPrefs = " + valSalvato);
    }
}


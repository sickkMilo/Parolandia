using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class EcoGiocoManager2 : MonoBehaviour
{
    public Button playButton;
    public GameObject wordButtonPrefab;
    public Transform buttonsContainer;
    public TextMeshProUGUI counterText;
    public GameObject feedbackPanel;
    public TextMeshProUGUI feedbackText;
    public AudioSource audioSource;
    public AudioClip suonoCorretto;
    public AudioClip suonoErrato;
    public GameObject livelloCompletatoPanel;
    public string livelloJsonPath = "EcoGioco/ecogioco_livello2";
    public string prossimaScena = "EcoGioco3";

    private List<EcoGiocoData> tutteLeDomande;
    private List<EcoGiocoData> domandeSelezionate;
    private int domandaCorrente = 0;
    private int paroleIndovinate = 1;
    private AudioClip clipCorrente;
    private MusicManager music;

    void Start()
    {
        music = TrovaMusicManager();
        music?.SpegniMusica();
        CaricaDati();
        InizializzaStep();
    }

    MusicManager TrovaMusicManager()
    {
        GameObject mm = GameObject.Find("MusicManager");
        return mm?.GetComponent<MusicManager>();
    }

    void CaricaDati()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(livelloJsonPath);
        tutteLeDomande = JsonUtility.FromJson<Wrapper>("{\"domande\":" + jsonFile.text + "}").domande;
        domandeSelezionate = tutteLeDomande.OrderBy(x => Random.value).Take(5).ToList();
    }

    void InizializzaStep()
    {
        if (domandaCorrente >= domandeSelezionate.Count)
        {
            livelloCompletatoPanel.SetActive(true);
            StartCoroutine(CaricaScenaProssima());
            return;
        }

        foreach (Transform child in buttonsContainer)
            Destroy(child.gameObject);

        EcoGiocoData domanda = domandeSelezionate[domandaCorrente];
        clipCorrente = Resources.Load<AudioClip>("AudioParole/" + domanda.audio);

        List<string> opzioni = new List<string>(domanda.distrattori);
        opzioni.Add(domanda.corretta);
        opzioni = opzioni.OrderBy(x => Random.value).ToList();

        foreach (string parola in opzioni)
        {
            GameObject btnObj = Instantiate(wordButtonPrefab, buttonsContainer);
            btnObj.GetComponentInChildren<TextMeshProUGUI>().text = parola;
            btnObj.GetComponent<Button>().onClick.AddListener(() => VerificaRisposta(parola, domanda.corretta));
        }

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => audioSource.PlayOneShot(clipCorrente));

        counterText.text = paroleIndovinate + " / 5";
        playButton.interactable = true;

    }

    void VerificaRisposta(string scelta, string corretta)
    {
        bool esatto = scelta == corretta;
        if (esatto)
        {
            feedbackText.text = "Bravo!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Riprova!";
            feedbackText.color = Color.red;
        }

        audioSource.PlayOneShot(esatto ? suonoCorretto : suonoErrato);
        feedbackPanel.SetActive(true);
        StartCoroutine(HandleFeedback(esatto));
    }

    IEnumerator HandleFeedback(bool esatto)
    {
        SetBottoniInterattivi(false);
        playButton.interactable = false;

        yield return new WaitForSeconds(0.5f);
        feedbackPanel.SetActive(false);

        if (esatto)
        {
            paroleIndovinate++;
            domandaCorrente++;
            yield return new WaitForSeconds(0.5f);
            InizializzaStep();
        }
        else
        {
            SetBottoniInterattivi(true);
            playButton.interactable = true;
        }
    }



    IEnumerator CaricaScenaProssima()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(prossimaScena);
    }

    public void TornaAlMenu()
    {
        StartCoroutine(RitornoAlMenuConMusica());
    }

    IEnumerator RitornoAlMenuConMusica()
    {
        //music?.RiattivaMusica();
        yield return new WaitForSeconds(0.1f); // piccolo delay per sicurezza
        SceneManager.LoadScene("SelectMiniGames");
    }


    void SetBottoniInterattivi(bool attivo)
    {
        foreach (Transform btn in buttonsContainer)
        {
            Button b = btn.GetComponent<Button>();
            if (b != null)
                b.interactable = attivo;
        }
    }

    [System.Serializable]
    private class Wrapper
    {
        public List<EcoGiocoData> domande;
    }
}
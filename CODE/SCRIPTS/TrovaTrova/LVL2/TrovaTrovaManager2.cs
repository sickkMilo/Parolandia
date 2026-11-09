using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class TrovaTrovaManager2 : MonoBehaviour
{
    public Image imageBox;
    public GameObject wordButtonPrefab;
    public Transform buttonsContainer;
    public TextMeshProUGUI counterText;
    public GameObject feedbackPanel;
    public TextMeshProUGUI feedbackText;
    public AudioSource audioSource;
    public AudioClip suonoCorretto;
    public AudioClip suonoErrato;
    public GameObject LivelloCompletatoPanel;

    private List<TrovaTrovaData> tutteLeDomande;
    private List<TrovaTrovaData> domandeSelezionate;
    private int domandaCorrente = 0;
    private int paroleIndovinate = 1;

    void Start()
    {
        CaricaDati();
        InizializzaStep();
    }

    void CaricaDati()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("TrovaTrova/livello2");
        tutteLeDomande = JsonUtility.FromJson<Wrapper>("{\"domande\":" + jsonFile.text + "}").domande;
        domandeSelezionate = tutteLeDomande.OrderBy(x => Random.value).Take(5).ToList();
    }

    void InizializzaStep()
    {
        if (domandaCorrente >= domandeSelezionate.Count)
        {
            LivelloCompletatoPanel.SetActive(true);
            StartCoroutine(CaricaScenaProssima("TrovaTrova3"));
            return;
        }

        foreach (Transform child in buttonsContainer)
            Destroy(child.gameObject);

        TrovaTrovaData domanda = domandeSelezionate[domandaCorrente];
        imageBox.sprite = Resources.Load<Sprite>("Immagini/" + domanda.immagine);

        List<string> opzioni = new List<string>(domanda.distrattori);
        opzioni.Add(domanda.corretta);
        opzioni = opzioni.OrderBy(x => Random.value).ToList();

        foreach (string parola in opzioni)
        {
            GameObject btnObj = Instantiate(wordButtonPrefab, buttonsContainer);
            btnObj.GetComponentInChildren<TextMeshProUGUI>().text = parola;
            btnObj.GetComponent<Button>().onClick.AddListener(() => VerificaRisposta(parola, domanda.corretta));
        }

        counterText.text = paroleIndovinate + " / 5";
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
        }
    }

    IEnumerator CaricaScenaProssima(string nomeScena)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nomeScena);
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
        public List<TrovaTrovaData> domande;
    }
}
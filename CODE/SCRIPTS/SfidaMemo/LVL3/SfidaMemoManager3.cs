using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class SfidaMemoManager3 : MonoBehaviour
{
    [Header("UI References")]
    public Image imageDisplay;
    public GameObject wordButtonPrefab;
    public Transform buttonsContainer;
    public TextMeshProUGUI counterText;
    public GameObject feedbackPanel;
    public TextMeshProUGUI feedbackText;
    public GameObject livelloCompletatoPanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip suonoCorretto;
    public AudioClip suonoErrato;

    [Header("Dati Livello")]
    public string livelloJsonPath = "SfidaMemo/sfidaMemo_livello3";
    public string prossimaScena = "SelectMiniGames";

    private List<MemoData> stepList;
    private List<string> sequenzaAttuale;
    private int currentStepIndex = 0;
    private int clickIndex = 0;
    private int completati = 1;

    void Start()
    {
        CaricaDati();
        IniziaStep();
    }

    void CaricaDati()
    {
        TextAsset file = Resources.Load<TextAsset>(livelloJsonPath);
        string jsonWrapped = "{\"lista\":" + file.text + "}";
        stepList = JsonUtility.FromJson<Wrapper>(jsonWrapped).lista.OrderBy(x => Random.value).ToList();
    }

    void IniziaStep()
    {
        sequenzaAttuale = stepList[currentStepIndex].sequenza;
        clickIndex = 0;
        counterText.text = $"{completati} / 5";

        foreach (Transform child in buttonsContainer)
            Destroy(child.gameObject);

        StartCoroutine(MostraSequenza());
    }

    IEnumerator MostraSequenza()
    {
        imageDisplay.gameObject.SetActive(true);
        foreach (string parola in sequenzaAttuale)
        {
            imageDisplay.sprite = Resources.Load<Sprite>("immagini/" + parola);
            yield return new WaitForSeconds(1.5f);
            imageDisplay.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            imageDisplay.gameObject.SetActive(true);
        }

        imageDisplay.gameObject.SetActive(false);
        CreaBottoni();
    }

    void CreaBottoni()
    {
        imageDisplay.gameObject.SetActive(false);
        List<string> mescolata = new List<string>(sequenzaAttuale).OrderBy(x => Random.value).ToList();

        foreach (string parola in mescolata)
        {
            GameObject btn = Instantiate(wordButtonPrefab, buttonsContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = parola;
            btn.GetComponent<Button>().onClick.AddListener(() => OnParolaClick(parola, btn));
        }
    }

    void OnParolaClick(string parola, GameObject bottone)
    {
        if (parola == sequenzaAttuale[clickIndex])
        {
            audioSource.PlayOneShot(suonoCorretto);
            MostraFeedback("BRAVO!", Color.green);

            bottone.GetComponent<Button>().interactable = false;
            bottone.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
            bottone.GetComponent<Image>().color = new Color(1, 1, 1, 0);

            clickIndex++;

            if (clickIndex >= sequenzaAttuale.Count)
            {
                completati++;
                if (completati >= 5)
                {
                    livelloCompletatoPanel.SetActive(true);
                    StartCoroutine(CaricaScenaSuccessiva());
                }
                else
                {
                    StartCoroutine(AvanzaStepConDelay());
                }
            }
        }
        else
        {
            audioSource.PlayOneShot(suonoErrato);
            MostraFeedback("RIPROVA!", Color.red);
        }
    }

    void MostraFeedback(string messaggio, Color colore)
    {
        feedbackText.text = messaggio;
        feedbackText.color = colore;
        feedbackPanel.SetActive(true);
        StartCoroutine(NascondiFeedback());
    }

    IEnumerator NascondiFeedback()
    {
        yield return new WaitForSeconds(0.5f);
        feedbackPanel.SetActive(false);
    }

    IEnumerator AvanzaStepConDelay()
    {
        yield return new WaitForSeconds(1f);
        currentStepIndex++;
        IniziaStep();
    }

    IEnumerator CaricaScenaSuccessiva()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(prossimaScena);
    }

    [System.Serializable]
    public class Wrapper
    {
        public List<MemoData> lista;
    }
}

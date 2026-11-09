using UnityEngine;
using UnityEngine.UI;

public class GuidaManager : MonoBehaviour
{
    public GameObject[] pagine; // Le 4 pagine
    public Button buttonAvanti;
    public Button buttonIndietro;
    public Button buttonChiudi;

    private int paginaCorrente = 0;

    void Start()
    {
        buttonAvanti.onClick.AddListener(PaginaSuccessiva);
        buttonIndietro.onClick.AddListener(PaginaPrecedente);
        buttonChiudi.onClick.AddListener(ChiudiGuida);

        MostraPagina(0); // Mostra la prima
    }

    void MostraPagina(int index)
    {
        for (int i = 0; i < pagine.Length; i++)
            pagine[i].SetActive(i == index); // Attiva solo quella corrente

        buttonIndietro.interactable = (index > 0);
        buttonAvanti.interactable = (index < pagine.Length - 1);
    }

    void PaginaSuccessiva()
    {
        if (paginaCorrente < pagine.Length - 1)
        {
            paginaCorrente++;
            MostraPagina(paginaCorrente);
        }
    }

    void PaginaPrecedente()
    {
        if (paginaCorrente > 0)
        {
            paginaCorrente--;
            MostraPagina(paginaCorrente);
        }
    }

    void ChiudiGuida()
    {
        this.gameObject.SetActive(false);
    }
}

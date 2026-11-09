using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void CaricaParoleNascondino()
    {
        SceneManager.LoadScene("ParoleCasuali_4Lettere");
    }
    public void TornaAlMenu()
    {
        SceneManager.LoadScene("SelectMiniGames");
    }
    public void CaricaTrovaTrova()
    {
        SceneManager.LoadScene("TrovaTrova1");
    }
    public void CaricaEcoGioco()
    {
        SceneManager.LoadScene("EcoGioco1");
    }
    public void CaricaSfidaMemo()
    {
        SceneManager.LoadScene("SfidaMemo1");
    }

}

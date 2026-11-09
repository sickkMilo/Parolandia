using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource musicSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AbbassaVolume() => SetVolume(0.1f);
    public void RipristinaVolume() => SetVolume(1.0f);
    public void SpegniMusica() => musicSource?.Stop();
    public void RiattivaMusica() { if (musicSource && !musicSource.isPlaying) musicSource.Play(); }

    public bool IsPlaying()
    {
        return musicSource != null && musicSource.isPlaying;
    }

    private void SetVolume(float vol)
    {
        if (musicSource != null)
            musicSource.volume = vol;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource SFX;
    public AudioSource penSource;

    [Header("----MUSIC----")]
    public AudioClip mainMusic;
    public AudioClip mackEnding;
    public AudioClip tiaEnding;
    [Header("----SFX----")]
    public AudioClip pageNoise1;
    public AudioClip pageNoise2;
    public AudioClip penSound1;
    public AudioClip penSound2;
    public AudioClip penSound3;
    public AudioClip penSound4;
    public AudioClip sparkle;

    private bool isMainMusicPlaying = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the scene loaded event
        PlayMainMusic(); // Play the main music by default
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MackEnding")
        {
            MackMusic();
        }
        else if (scene.name == "TiaEnding")
        {
            TiaMusic();
        }
        else
        {
            if (!isMainMusicPlaying) // Check if the main music is not already playing
            {
                PlayMainMusic();
            }
        }
    }

    public void PlayMainMusic()
    {
        music.clip = mainMusic;
        music.Play();
        isMainMusicPlaying = true;
    }

    public void MackMusic()
    {
        music.clip = mackEnding;
        music.Play();
        isMainMusicPlaying = false; // Main music is not playing when ending music is playing
    }

    public void TiaMusic()
    {
        music.clip = tiaEnding;
        music.Play();
        isMainMusicPlaying = false; // Main music is not playing when ending music is playing
    }

    //public void WritingSFX()
    //{
    //    int randomIndex = Random.Range(0, 2);

    //    if (randomIndex == 0)
    //    {
    //        SFX.PlayOneShot(penSound1);
    //    }
    //    else
    //    {
    //        SFX.PlayOneShot(penSound2);
    //    }
    //}

    public void PenSFX()
    {
        if (!penSource.isPlaying)
        {
            int randomIndex = Random.Range(0, 4); // Generates a random index between 0 and 3
            AudioClip randomPenSound = null;

            // Select the random sound effect based on the random index
            switch (randomIndex)
            {
                case 0:
                    randomPenSound = penSound1;
                    break;
                case 1:
                    randomPenSound = penSound2;
                    break;
                case 2:
                    randomPenSound = penSound3;
                    break;
                case 3:
                    randomPenSound = penSound4;
                    break;
                default:
                    Debug.LogError("Invalid random index for pen sound effects.");
                    return;
            }

            // Play the selected random sound effect
            penSource.PlayOneShot(randomPenSound);
        }
    }

    public void PaperSFX()
    {
        if (!SFX.isPlaying)
        {
            int randomIndex = Random.Range(0, 2); // Generates a random index between 0 and 1
            AudioClip randomPenSound = randomIndex == 0 ? pageNoise1 : pageNoise2;
            SFX.PlayOneShot(randomPenSound);
        }
    }

    public void SparkSFX()
    {
        SFX.PlayOneShot(sparkle);
    }


}

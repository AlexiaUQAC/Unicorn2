using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource dialogueSource;
    
    [Header("Audio Clips")]
    public AudioClip grabCollectible;
    public AudioClip trashCollectible;
    public AudioClip shootProjectile;
    public AudioClip door;
    public AudioClip scan;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    private void PlaySFX(AudioClip sfx)
    {
        sfxSource.clip = sfx;
        sfxSource.Play();
    }
    
    public void PlayGrabCollectible()
    {
        PlaySFX(grabCollectible);
    }
    
    public void PlayTrashCollectible()
    {
        PlaySFX(trashCollectible);
    }
    
    public void PlayShootProjectile()
    {
        PlaySFX(shootProjectile);
    }
    
    public void PlayDialogue()
    {
        dialogueSource.Play();
    }
    
    public void StopSFX()
    {
        sfxSource.Stop();
    }
    
    public void StopDialogue()
    {
        dialogueSource.Stop();
    }

    public void PlayDoor()
    {
        PlaySFX(door);
    }

    public void PlayScan()
    {
        PlaySFX(scan);
    }
}

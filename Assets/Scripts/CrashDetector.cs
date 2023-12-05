using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crushSystem;
    [SerializeField] AudioClip crashSFX;

    SurfaceEffector2D surfaceEffector2D;

    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crushSystem.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);

        }
        else if (hasCrashed)
        {
            Invoke("ReloadScene", reloadDelay);
        }

        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

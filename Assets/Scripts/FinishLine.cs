using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip finishSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(finishSFX);
            Invoke("ReloadScene", reloadDelay);
            
        }

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }


}

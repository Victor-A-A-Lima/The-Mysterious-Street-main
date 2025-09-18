using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;


 public void PlayEffect()
 {
    // Toca quando for chamado (ex: botão ou evento)
    audioSource.PlayOneShot(audioSource.clip);
 }
}
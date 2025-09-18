using UnityEngine;

public class Porta : MonoBehaviour

{

    public GameObject portaFechada;
    public GameObject portaAberta;
    public AudioClip somAbrindo;
    private AudioSource audioSource;

    void Start()

    {



        if (portaAberta != null)

            portaAberta.SetActive(false);


        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

    }

    public void AbrirPorta()

    {

        if (portaFechada != null && portaAberta != null)

        {


            if (somAbrindo != null && audioSource != null)

                audioSource.PlayOneShot(somAbrindo);

            portaFechada.SetActive(false);

            portaAberta.SetActive(true);

        }

        else

        {

            Debug.LogWarning("Porta fechada ou aberta não definida!");

        }

    }
}
 
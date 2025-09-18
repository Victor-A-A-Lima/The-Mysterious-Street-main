using UnityEngine;
using UnityEngine.UI;

public class PopupImagem : MonoBehaviour
{
    public Image imagem;
    public float intervalo = 5f;
    public float duracao = 2f;

    private void Start()
    {
        imagem.gameObject.SetActive(false);
        StartCoroutine(CicloImagem());
    }

    private System.Collections.IEnumerator CicloImagem()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            imagem.gameObject.SetActive(true);
            yield return new WaitForSeconds(duracao);
            imagem.gameObject.SetActive(false);
        }
    }
}

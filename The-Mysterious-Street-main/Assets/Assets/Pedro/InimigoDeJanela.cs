using UnityEngine;
using UnityEngine.Events;

public class InimigoDeJanela : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite alertaSprite;
    public float tempoParaMudar = 5f; 
    public float tempoReacao = 2f;    
    private SpriteRenderer spriteRenderer;
    private bool emAlerta = false;
    private float tempoDesdeMudanca = 0f;
    public GameObject objetoParaVerificar;
    ChoiceCode choiceCode;

    void Start()
    {
        
        choiceCode = FindFirstObjectByType(typeof(ChoiceCode)) as ChoiceCode;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = originalSprite;
        InvokeRepeating("MudarParaAlerta", tempoParaMudar, tempoParaMudar);
    }

    void Update()
    {
        if (emAlerta)
        {
            tempoDesdeMudanca += Time.deltaTime;

            if (tempoDesdeMudanca >= tempoReacao)
            {
                DanoDoInimigoDaJanela();
            }
        }
        if (objetoParaVerificar.activeInHierarchy)
        {
            enabled = false;
        }
        else
        {

        }
    }

    void MudarParaAlerta()
    {
        if (!emAlerta)
        {
            spriteRenderer.sprite = alertaSprite;
            emAlerta = true;
            tempoDesdeMudanca = 0f;
        }
    }

    void OnMouseDown()
    {
        if (emAlerta)
        {
            // Clicou a tempo
            spriteRenderer.sprite = originalSprite;
            emAlerta = false;
            tempoDesdeMudanca = 0f;
        }
    }

    void DanoDoInimigoDaJanela()
    {
        choiceCode.life -= 45;
    }
}

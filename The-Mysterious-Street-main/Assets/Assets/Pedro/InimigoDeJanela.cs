using UnityEngine;

public class InimigoDeJanela : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite alertaSprite;

    public float tempoParaMudar = 5f; // Tempo entre mudanças
    public float tempoReacao = 2f;    // Tempo para clicar após mudar

    private SpriteRenderer spriteRenderer;
    private bool emAlerta = false;
    private float tempoDesdeMudanca = 0f;

    void Start()
    {
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
                GameOver();
            }
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

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Aqui você pode carregar uma nova cena, pausar o jogo, etc.
        // Por exemplo:
        // SceneManager.LoadScene("GameOverScene");
        CancelInvoke(); // Para parar de chamar MudarParaAlerta
        enabled = false; // Desabilita o script
    }
}

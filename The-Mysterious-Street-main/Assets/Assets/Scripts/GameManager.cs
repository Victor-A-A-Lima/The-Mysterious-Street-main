
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject mario;
    public GameObject marioMonstro;
    public GameObject richard;
    public GameObject richardMonstro;
    public GameObject djonesMonstro;

    AudioManager musicManager;

    bool HasVictory = false;

    public string sceneName;

    NpcInvoker npcInvoker;
    ChoiceCode choiceCode;

    int npc;
    int quantidadeNpc;

    public float sceneDelay = 2f;

    List<int> npcVerify = new List<int>();

    void Start()
    {
        musicManager = FindAnyObjectByType(typeof(AudioManager)) as AudioManager;
        choiceCode = FindAnyObjectByType(typeof(ChoiceCode)) as ChoiceCode;
        npcInvoker = FindAnyObjectByType(typeof(NpcInvoker)) as NpcInvoker;
    }

    void Update()
    {
        if (quantidadeNpc == 5 && !HasVictory)
        {
            Debug.Log("VENCEU");
            HasVictory = true;
            npcVerify.Clear();
            StartCoroutine(Victory(sceneDelay));
        }
    }

    private int randomNumber()
    {
        return Random.Range(1, 6); // Inclui 5 agora
    }

    public void OpenDoor()
    {
        if (!HasVictory)
        {
            // Todos os NPCs já foram usados
            if (npcVerify.Count >= 5)
            {
                Debug.LogWarning("Todos os NPCs já foram usados.");
                return;
            }

            int attempts = 0;
            do
            {
                npc = randomNumber();
                attempts++;

                // Evita loop infinito
                if (attempts > 10)
                {
                    Debug.LogError("Não foi possível sortear um novo NPC.");
                    return;
                }

            } while (npcVerify.Contains(npc));

            npcVerify.Add(npc);
            npcInvoker.NpcChoicer(npc);
            choiceCode.Door("aberta");
            Debug.Log($"NPC escolhido: {npc}");
        }
    }

    public void CloseTheDoor()
    {
        if (npc == 1)
        {
            choiceCode.LoseSanity();
            mario.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
        }
        else if (npc == 2)
        {
            choiceCode.SanityGain();
            marioMonstro.SetActive(false);
            quantidadeNpc++;
        }
        else if (npc == 3)
        {
            choiceCode.LoseSanity();
            richard.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
        }
        else if (npc == 4)
        {
            choiceCode.SanityGain();
            richardMonstro.SetActive(false);
            quantidadeNpc++;
        }
        else if (npc == 5)
        {
            choiceCode.SanityGain();
            djonesMonstro.SetActive(false);
            quantidadeNpc++;
        }

        choiceCode.Door("fechada");
        TextManager.Instance.CloseText();
    }

    public void Candy()
    {
        if (npc == 1)
        {
            choiceCode.SanityGain();
            mario.SetActive(false);
            quantidadeNpc++;
        }
        else if (npc == 2)
        {
            choiceCode.LoseSanity();
            marioMonstro.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
        }
        else if (npc == 3)
        {
            choiceCode.SanityGain();
            richard.SetActive(false);
            quantidadeNpc++;
        }
        else if (npc == 4)
        {
            choiceCode.LoseSanity();
            richardMonstro.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
        }
        else if (npc == 5)
        {
            choiceCode.LoseSanity();
            djonesMonstro.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
        }

        choiceCode.Door("fechada");
        TextManager.Instance.CloseText();
    }

    IEnumerator Victory(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
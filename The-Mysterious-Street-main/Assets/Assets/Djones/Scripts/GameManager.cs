
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

    AudioManager musicManager;

    bool HasVictory = false;

    public string sceneName;
    
    NpcInvoker npcInvoker;
    
    ChoiceCode choiceCode;
    
    int npc;
    int quantidadeNpc;

    public float sceneDelay = 2f;

    List<int> npcVerify = new List<int> {};

    void Start()
    {
       musicManager = FindAnyObjectByType(typeof(AudioManager)) as AudioManager;
       choiceCode = FindAnyObjectByType(typeof(ChoiceCode)) as ChoiceCode;
       npcInvoker = FindAnyObjectByType(typeof(NpcInvoker)) as NpcInvoker;     
    }


    void Update()
    {
        if (quantidadeNpc == 4 && !HasVictory) 
        {
            Debug.Log("VENCEU");
            HasVictory = true;
            npcVerify.Clear();
            StartCoroutine(Victory(sceneDelay));
        }
    }
    private void randomNumber()
    {
        npc = Random.Range(1, 5);
        Debug.Log($" range {npc}");
    }
    public void OpenDoor()
    {
        if (!HasVictory)
        {
            randomNumber();
            if (npcVerify.Contains(npc))
            {
                OpenDoor();
            }
            npcVerify.Add(npc);
            npcInvoker.NpcChoicer(npc);
            choiceCode.Door("aberta");
            Debug.Log($"numero final {npc}");
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
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
        else if (npc == 2)
        {
            choiceCode.SanityGain();
            marioMonstro.SetActive(false);
            quantidadeNpc++;
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
        else if(npc == 3)
        {
            choiceCode.LoseSanity();
            richard.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
        else if (npc == 4) 
        {
            choiceCode.SanityGain();
            richardMonstro.SetActive(false);
            quantidadeNpc++;
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
    }

    public void Candy()
    {
        if (npc == 1)
        {
            choiceCode.SanityGain();
            mario.SetActive(false);
            quantidadeNpc++;
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
        else if (npc == 2)
        {
            choiceCode.LoseSanity();
            marioMonstro.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
        else if (npc == 3)
        {
            choiceCode.SanityGain();
            richard.SetActive(false);
            quantidadeNpc++;
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
        else if (npc == 4) 
        {
            choiceCode.LoseSanity();
            richardMonstro.SetActive(false);
            quantidadeNpc++;
            musicManager.PlayEffect();
            choiceCode.Door("fechada");
            TextManager.Instance.CloseText();
        }
    }


    IEnumerator Victory(float delay)
    {
        Debug.Log("VENCEU");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

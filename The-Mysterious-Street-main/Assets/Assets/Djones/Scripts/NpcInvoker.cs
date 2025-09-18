using UnityEngine;

public class NpcInvoker : MonoBehaviour
{
    DialogueInvoker dialogueInvoker;
    public GameObject mario;
    public GameObject marioMonstro;
    public GameObject richard;
    public GameObject richardMonstro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueInvoker = FindAnyObjectByType(typeof(DialogueInvoker)) as DialogueInvoker;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NpcChoicer(int x)
    {
        if (x == 1)
        {
            mario.SetActive(true);
            dialogueInvoker.Interact("mario");
        }
        else if (x == 2)
        {
            marioMonstro.SetActive(true);
            dialogueInvoker.Interact("marioMonstro");
        }
        else if (x == 3)
        {
            richard.SetActive(true);
            dialogueInvoker.Interact("richard");
        }
        else if (x == 4) 
        {
            richardMonstro.SetActive(true);
            dialogueInvoker.Interact("richardMonstro");
        }

    }

}

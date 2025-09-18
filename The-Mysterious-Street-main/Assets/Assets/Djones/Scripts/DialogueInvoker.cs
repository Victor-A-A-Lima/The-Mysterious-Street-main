using UnityEngine;

public class DialogueInvoker : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] linesMario;
    public string[] linesMarioMonstro;
    public string[] linesRichard;
    public string[] linesRichardMonstro;

    bool interactedMario = true;
    bool interactedMarioMonstro = true;
    bool interactedRichard = true;
    bool interactedRichardMonstro = true;
    public void Interact(string pessoa)
    {
        if (pessoa == "mario")
        {
            if (interactedMario)
            {
                interactedMario = false;
                TextManager.Instance.StartDialogue(linesMario);
            }
        }
        else if (pessoa == "marioMonstro") 
        {
            if (interactedMarioMonstro)
            {
                interactedMarioMonstro = false;
                TextManager.Instance.StartDialogue(linesMarioMonstro);
            }
        }
        else if (pessoa == "richard")
        {
            if (interactedRichard)
            {
                interactedRichard = false;
                TextManager.Instance.StartDialogue(linesRichard);
            }
        }
        else if (pessoa == "richardMonstro")
        {
            if (interactedRichardMonstro)
            {
                interactedRichardMonstro = false;
                TextManager.Instance.StartDialogue(linesRichardMonstro);
            }
        }
    }
}

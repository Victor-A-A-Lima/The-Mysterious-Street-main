using UnityEngine;

public class LeaveCode : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Jogo fechado!");
    }
}

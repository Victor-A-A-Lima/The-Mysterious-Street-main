using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Events;
public class ChoiceCode : MonoBehaviour
{
    int npcNumber;
    public Slider slider;
    public float life = 100f;// float pois o jogador não se movimenta no eixo x 0.1 unidades no trecho de um frame
    public float lifeMax = 100f;
    public float danoPorSegundo = 0.01f;
    public string sceneName;
    public float sceneDelay = 2f;
    bool hasLost = false;
    bool doorOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        life = Mathf.Clamp(life, 0, lifeMax);// limita a vida para menos q 0 
        slider.value = life;
        slider.maxValue = lifeMax;

        if (doorOpen == true)
        {
            life -= danoPorSegundo * Time.deltaTime;
        }
        
        if (life <= 0 && hasLost == false)
        {
            hasLost = true;
            StartCoroutine(Defeat(sceneDelay));
        }
    }
    IEnumerator Defeat(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void LoseSanity()
    {
        life -= 45;
    }

    public void SanityGain() 
    {
       life += 10;
    }

    public void Door(string porta)
    {
        if (porta == "aberta")
        {
            doorOpen = true;
        }
        if (porta == "fechada")
        {
            doorOpen = false;
        }
    }
}

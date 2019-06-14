using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameContral : MonoBehaviour
{

    public GameObject endUI;
    public Text endMessage;

    public static GameContral Instance;
    private EnemyCreater enemycreater;
    void Awake()
    {
        Instance = this;
        enemycreater = GetComponent<EnemyCreater>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "You win";
    }
    public void Failed()
    {
        enemycreater.Stop();
        endUI.SetActive(true);
        endMessage.text = "You lose";
    }
    public void OnButtenAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnButtenMenu()
    {
        SceneManager.LoadScene(0);
    }
}

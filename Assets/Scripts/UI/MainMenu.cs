using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        Debug.Log("StartGame");
        SceneManager.LoadScene("Game");
    }

    public void StartGameChallenge(){
        Debug.Log("StartGame_Challenge");
        SceneManager.LoadScene("Game_Challenge");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

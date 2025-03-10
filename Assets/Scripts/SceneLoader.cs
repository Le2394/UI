using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public Button playButton;
    public Button backButton;

    public static string lastScene = "";

    /*public void LoadNextScene()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(CurrentScene);
        if (CurrentScene < 2)
            SceneManager.LoadScene(CurrentScene + 1);
    }

    public void LoadLastScene()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        if (CurrentScene > 0)
            SceneManager.LoadScene(CurrentScene - 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(2);
    }*/

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    void OnBackButtonClicked()
    {
        if (backButton)
        {
            if (SceneManager.GetActiveScene().name != "Waiting")
            {
                lastScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Waiting");
            }
        }
    }
    void OnPlayButtonClicked()
    { 
        if(playButton)
        {
            if (SceneManager.GetActiveScene().name != "Waiting")
            {
                lastScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Waiting");
            }
        }
    }
    void OnDestroy()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        if (backButton != null)
        {
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }
    }
}

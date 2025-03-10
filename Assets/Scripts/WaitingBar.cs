using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ScrollBarSizeController : MonoBehaviour
{
    public Scrollbar myScrollBar;
    void Start()
    {
        if (myScrollBar != null)
        {
            StartCoroutine(ChangeScrollBarSizeOverTime(1f, 1f));
        }
    }

    IEnumerator ChangeScrollBarSizeOverTime(float targetSize, float duration)
    {
        float startSize = myScrollBar.size;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            myScrollBar.size = Mathf.Lerp(startSize, targetSize, elapsedTime / duration);
            yield return null;
        }

        myScrollBar.size = targetSize;
        
        if (SceneLoader.lastScene == "Begin")
        {
            SceneManager.LoadScene("Back");
            SceneLoader.lastScene = "Back";
        }
        
        else if(SceneLoader.lastScene == "Back")
        {
            SceneManager.LoadScene("Begin");
            SceneLoader.lastScene = "Begin";
        }
        Debug.Log(SceneLoader.lastScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Animator SceneTransition;
    public void OnPlayButtonPressed()
    {
        PlayerPrefs.SetInt("TimeToLoad", 0);//new
        PlayerPrefs.Save();
        StartCoroutine("LoadLevel");
    }
    
    IEnumerator LoadLevel()
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");

    }
}

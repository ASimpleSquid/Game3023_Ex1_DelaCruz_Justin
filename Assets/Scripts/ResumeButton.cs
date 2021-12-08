using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{

    public Animator SceneTransition;
    public void OnResumeButtonPressed()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);//load
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

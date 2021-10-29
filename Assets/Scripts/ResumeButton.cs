using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void OnResumeButtonPressed()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);//load
        PlayerPrefs.Save();
        SceneManager.LoadScene("SampleScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public Animator SceneTransition;
    public void OnExitButtonPressed()
    {
        StartCoroutine("LoadLevel");
        Debug.Log("Quitted Application");
    }

    IEnumerator LoadLevel()
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        Application.Quit();


    }
}

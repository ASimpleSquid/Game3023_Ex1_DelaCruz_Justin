using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quitted Application");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public GameObject player;
    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetFloat("p_z", player.transform.position.z);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
        Debug.Log("player position saved!");
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float px;
            float py;
            float pz;
            px = PlayerPrefs.GetFloat("p_x");
            py = PlayerPrefs.GetFloat("p_y");
            pz = PlayerPrefs.GetFloat("p_z");
            Debug.Log("player position loaded");
            player.transform.position = new Vector3(px, py, pz);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
    }
}

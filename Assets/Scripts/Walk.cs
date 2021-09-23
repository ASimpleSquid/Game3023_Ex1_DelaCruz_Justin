using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // This is to ensure the speed is set at a stable 1. This can be modified in Unity
    public float WalkSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The Horizontal Axis ensures we can move left and right, with transform position
        // we can move around using time and our walk speed
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * WalkSpeed;
    }
}

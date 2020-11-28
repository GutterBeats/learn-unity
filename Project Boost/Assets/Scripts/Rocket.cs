using System;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    // Use this for initialization
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInput();
    }

    private static void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
        }
    }
}

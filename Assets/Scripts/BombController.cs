using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float lifetime = 3f;
    
    void Start()
    {
        Destroy (gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

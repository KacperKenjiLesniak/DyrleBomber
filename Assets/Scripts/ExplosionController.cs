using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private float lifetime = 1f;
    
    void Start()
    {
        Destroy (gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

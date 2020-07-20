using System;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    public float baseSpeed = 1.0f;
    
    private Vector2 movement;
    
    public Rigidbody2D rb;

    public GameObject bombPrefab;
    
    public static GameObject LocalPlayerInstance;

    void Awake()
    {
        if (photonView.IsMine)
        {
            LocalPlayerInstance = gameObject;
        }
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            if (Input.GetButtonDown("Jump"))
            {
                SpawnBomb();
            }
        }
    }

    private void SpawnBomb()
    {
        PhotonNetwork.Instantiate(bombPrefab.name, transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            rb.MovePosition(rb.position + movement * baseSpeed * Time.fixedDeltaTime);
        }
    }
}
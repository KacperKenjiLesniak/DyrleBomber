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
        var bomb = PhotonNetwork.Instantiate(bombPrefab.name, RoundPosition(transform.position), Quaternion.identity);
        bomb.GetComponent<BombController>().spawningPlayerTransform = transform;
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            rb.MovePosition(rb.position + movement * baseSpeed * Time.fixedDeltaTime);
        }
    }

    Vector3 RoundPosition(Vector3 position)
    {
        return new Vector3(Mathf.Ceil(position.x) - 0.5f, Mathf.Ceil(position.y) - 0.5f, position.z);
    }
}
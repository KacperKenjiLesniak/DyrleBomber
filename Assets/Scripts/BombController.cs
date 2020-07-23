using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BombController : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update

    public Transform spawningPlayerTransform;
    
    private float lifetime = 3f;

    [SerializeField]
    private Collider2D bombCollider;

    [SerializeField] private GameObject explosion;
    
    void Start()
    {
        Invoke("SpawnExplosion", 2.9f);
        Destroy (gameObject, lifetime);
    }

    void SpawnExplosion()
    {
        var explosion1 = PhotonNetwork.Instantiate(explosion.name, transform.position, Quaternion.identity);
        var explosion2 = PhotonNetwork.Instantiate(explosion.name, transform.position, Quaternion.identity);
        explosion1.transform.localScale = new Vector3(2f, 0.3f, 1f);
        explosion2.transform.localScale = new Vector3(0.3f, 2f, 1f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (spawningPlayerTransform != null)
        {
            if (Vector2.Distance(transform.position, spawningPlayerTransform.position) > 1)
            {
                bombCollider.enabled = true;
            }
        }
    }
        
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(bombCollider.enabled);
        }
        else
        {
            // Network player, receive data
            if ((bool) stream.ReceiveNext())
            {
                bombCollider.enabled = true;
            }
        }
    }
}

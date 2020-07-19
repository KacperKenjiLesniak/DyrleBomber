using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Board : MonoBehaviourPun
{

    [SerializeField]
    private GameObject brick;

    [SerializeField]
    private Transform bricks;

    bool [,] brickBoard = new bool[20, 12];
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < brickBoard.GetLength(0); i++)
            {
                for (int j = 0; j < brickBoard.GetLength(1); j++)
                {
                    brickBoard[i, j] = Random.Range(0.0f, 1.0f) > 0.8f;

                    SetCornersToFalse();

                    if (brickBoard[i, j])
                    {
                        var brickInstance = PhotonNetwork.Instantiate(brick.name, new Vector3(i - 9.5f, j - 5.5f, 0f),
                            Quaternion.identity);
                        brickInstance.transform.SetParent(bricks);
                    }
                }
            }
        }
    }

    private void SetCornersToFalse()
    {
        brickBoard[brickBoard.GetLength(0) - 1, brickBoard.GetLength(1) - 1] = false;
        brickBoard[brickBoard.GetLength(0) - 1, brickBoard.GetLength(1) - 2] = false;
        brickBoard[brickBoard.GetLength(0) - 2, brickBoard.GetLength(1) - 1] = false;

        brickBoard[0, brickBoard.GetLength(1) - 1] = false;
        brickBoard[1, brickBoard.GetLength(1) - 1] = false;
        brickBoard[0, brickBoard.GetLength(1) - 2] = false;

        brickBoard[0, 0] = false;
        brickBoard[1, 0] = false;
        brickBoard[0, 1] = false;

        brickBoard[brickBoard.GetLength(0) - 1, 0] = false;
        brickBoard[brickBoard.GetLength(0) - 1, 1] = false;
        brickBoard[brickBoard.GetLength(0) - 2, 0] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

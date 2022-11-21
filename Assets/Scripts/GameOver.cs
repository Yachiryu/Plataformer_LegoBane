using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Playerpos;
    public Transform[] checkPoints;
    public int checkpIndex;

    private void Start()
    {
        checkpIndex = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CoinReached();
        }
    }

    public void CoinReached()
    {
        Playerpos.transform.position = checkPoints[checkpIndex].transform.position;
        Debug.Log("CheckPoint");
    }

}

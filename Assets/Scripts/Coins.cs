using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{ 
    public AudioClip audiofx;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audiofx, gameObject.transform.position);
            if (audiofx == true)
            {
                Destroy(this.gameObject);
            }
               
        }
    }
}

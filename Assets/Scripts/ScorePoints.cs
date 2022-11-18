using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    private int puntaje;
    public TextMeshProUGUI puntajeText;
    void Start()
    {
        puntaje = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moneda")
        {
            puntaje++;
            puntajeText.text = "" + puntaje;
        }
    }
}

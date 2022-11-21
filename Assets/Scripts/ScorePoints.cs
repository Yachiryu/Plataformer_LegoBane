using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScorePoints : MonoBehaviour
{
    public int puntaje;
    public TextMeshProUGUI puntajeText;
    public GameOver gameOver;
    public string scene;
    void Start()
    {
        puntaje = 0;
    }
    private void Update()
    {
        if (puntaje >= 3)
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moneda")
        {
            puntaje++;
            puntajeText.text = "" + puntaje;
        }

        if (other.gameObject.tag == "CheckP1")
        {
            gameOver.checkpIndex = 1;
        }
        if (other.gameObject.tag == "CheckP2")
        {
            gameOver.checkpIndex = 2;
        }
        if (other.gameObject.tag == "CheckP3")
        {
            gameOver.checkpIndex = 3;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    int vida;
    float losecontrol = 0.5f;

    public GameObject[] corazones;
    public event EventHandler muertejugador;
    Movements moves;

    void Start()
    {
        vida = corazones.Length;
        moves = GetComponent<Movements>();
    }

    public void Daño(Vector2 position)
    {
        vida--;
        StartCoroutine(LoseControl());
        moves.Volver(position);

        if (vida < 1) {
            Destroy(corazones[0].gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        } else if (vida < 2) {
            Destroy(corazones[1].gameObject);
        } else if (vida < 3) {
            Destroy(corazones[2].gameObject);
        } else if (vida < 4) {
            Destroy(corazones[3].gameObject);
        } else if (vida < 5) {
            Destroy(corazones[4].gameObject);
        }
        
    }
    private IEnumerator LoseControl() {
        moves.sepuedemov = false;
        yield return new WaitForSeconds(losecontrol);
        moves.sepuedemov = true;
    }
}

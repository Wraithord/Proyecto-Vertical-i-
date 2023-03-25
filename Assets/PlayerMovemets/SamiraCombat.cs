using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamiraCombat : MonoBehaviour
{
    [SerializeField] private float hp;
    private Movements movementsamira;
    [SerializeField] private float timeperdcont;
    private Animator animator;
    Movements moves;


    private void Start()
    {
        movementsamira = GetComponent<Movements>();
        animator = GetComponent<Animator>();
    }

    public void Daño(Vector2 posicion) 
    {
        hp--;
        StartCoroutine(PerdeControl());
        moves.Volver(posicion);
    }
    private IEnumerator PerdeControl()
    {
        movementsamira.sepuedemov = false;
        yield return new WaitForSeconds (timeperdcont);
        movementsamira.sepuedemov = true;
    }
}
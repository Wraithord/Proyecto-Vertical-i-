using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracola : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigib2denemy;
    [SerializeField] private float Veloc;
    [SerializeField] private Transform Controlsuelo;
    [SerializeField] private float Distancia;
    [SerializeField] private bool MovimientoDerecha;
   

    private void Start()
    {
        animator = GetComponent<Animator>();  
        rigib2denemy = GetComponent<Rigidbody2D>(); 
    }

     private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(Controlsuelo.position, Vector2.down, Distancia);

        rigib2denemy.velocity = new Vector2(Veloc, rigib2denemy.velocity.y);

        if(informacionSuelo == false)
        {
            Girar();
        }

    }
     private void Girar()
    {
        MovimientoDerecha = !MovimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        Veloc *= -1f;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") 
        {
            foreach (ContactPoint2D point in collision.contacts) {
                if (point.normal.y <= -0.1f) 
                {
                    collision.gameObject.GetComponent<Movements>().Rebotes();
                    Destroy(gameObject);
                    return;
                } else {
                    collision.gameObject.GetComponent<Vida>().Daño(point.normal);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawLine(Controlsuelo.transform.position, Controlsuelo.transform.position + Vector3.down * Distancia);
    }
}

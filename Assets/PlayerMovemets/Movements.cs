   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    //Controlar la velocidad del personaje y cantidad del salto

    public float rspeed = 2f; //La "f" se coloca siempre y cuando sea un float y est� en decimal ej; 2,1.
 
    public float sjump = 3; // No hay necesidad de colocar la "f"

    Rigidbody2D rigb2D; // Variable tipo publica y se puede modificar y se puede editar desde editor e ir probando diferentes valores

    // Volver

    public bool puedemov = true;

    public Vector2 velocityVolver;

    // Se puede Mover el "Player"

    public bool sepuedemov = true;

    // Rebote del "Player" al saltar el enemigo

    [SerializeField] private Vector2 velrebote;

    [Header("rebote")]

    float velrebot;
    
    // Componente para el Animator

    private static Animator animator;

    // Regular el salto y mejorarlo

    public bool betterjump = false; // Booleano para calcular el salto si se presiona m�s o menos

    public float falljumpmultiplayer = 0.5f;

    public float lowjumpmultiplayer = 1f;

    // Variables Coyote Time

    bool escoyote = false;
    float tiempocoyote;
    public float tiempocoyotetime = 0.1f;

    // Variables para la animación del personaje

  // public SpriteRenderer spriterender;
    public GameObject Samira;
    public Animator animacion;

    //  M�todo que inicializa el movimiento del personaje desde el primer frame (imagen)
    void Start()
    {
        rigb2D = GetComponent<Rigidbody2D>(); // Inicialic� un componente del rigidboy, se agrega el componente al personaje
        animator = GetComponent<Animator>(); 
    }

    public void Rebote()
    {
        rigb2D.velocity = new Vector2(rigb2D.velocity.x, velrebot);
    }


    // Se cambia de m�todo de "Update" a "FixedUpdate", para trabajar con muchos condicionales y funciones.
    void FixedUpdate() //Cambiar el m�todo de "Update" a "Fix" para usar muchas variables
    {
        if (sepuedemov)
        {
            //Movimiento hac�a la derecha

            if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))   // ("d") si es string puede ser may�scula o min�scula
            {
                rigb2D.velocity = new Vector2(rspeed, rigb2D.velocity.y);
                Samira.transform.localScale = new Vector2(1, 1);
                animacion.SetBool("Run", true);
                // spriterender.flipX = false;
            }

            //Movimiento hac�a la izquierda

            else if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
            {
                rigb2D.velocity = new Vector2(-rspeed, rigb2D.velocity.y);
                Samira.transform.localScale = new Vector2(-1, 1);
                animacion.SetBool("Run", true);
                // spriterender.flipX = true;
            }
            else
            {
                rigb2D.velocity = new Vector2(0, rigb2D.velocity.y);
                animacion.SetBool("Run", false);
            }
        }

        //Personaje sin moverse


        // Saltar y qu� reconozca el terreno + coyote time

        if (Input.GetKey(KeyCode.Space) && (CheckGround.isground || escoyote))
        {
            rigb2D.velocity = new Vector2(rigb2D.velocity.x, sjump);
        }

        if (CheckGround.isground == false) 
        {
            animacion.SetBool("Jump", true);
            animacion.SetBool("Run", false);
        }
        if (CheckGround.isground == true)
        {
            animacion.SetBool("Jump", false);
        }


        // Salto mejorado

        if (betterjump)
        {
            if (rigb2D.velocity.y<0)
            {
                rigb2D.velocity += Vector2.up * Physics2D.gravity.y * (falljumpmultiplayer) * Time.deltaTime;
            }
            if (rigb2D.velocity.y>0 && !Input.GetKey(KeyCode.Space))
            {
                rigb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmultiplayer) * Time.deltaTime;
            }
        }

        // Coyote Time

        if (CheckGround.isground)
        {
            escoyote = true;
            tiempocoyote = 0;
        }
        if (!CheckGround.isground && escoyote) 
        { 
            tiempocoyote += Time.deltaTime;
            if (tiempocoyote > tiempocoyotetime) 
                escoyote = false;
        }
    }
    public void Rebotes()
    {
        rigb2D.velocity = new Vector2(rigb2D.velocity.x, 16f);
    }

    public void Volver(Vector2 PuntoGolpe) {
        rigb2D.velocity = new Vector2(-velocityVolver.x * PuntoGolpe.x, velocityVolver.y);
    }
}

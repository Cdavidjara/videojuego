using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float fuerzaSalto;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private bool estaSuelo;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //listo para ser manipulado
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        estaSuelo=true;
    }

    // Update is called once per frame
    void Update()
    {
        //detecta una tecla para saltar (mov)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //el set depende del tipo que deseo
            animator.SetBool("estarSuelo", true);
            //se afecta la fuerza y se mueve con el vector, sse mueve en y porque salta
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            estaSuelo = false;  
        }
    }
    //para detectar la colision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //la colisio evalua con la etiqueta suelo 
        //para que tope suelo y se dispara la anumacion
        if (collision.gameObject.tag == "Suelo") {
            animator.SetBool("estarSuelo", false);
            estaSuelo = true;
        }

        //aqui se controla cuando choca o colisiona
        if(collision.gameObject.tag == "obstaculo")
        {
            gameManager.gameOver = true;
        }



    }
}

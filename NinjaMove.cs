using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMove : MonoBehaviour
{
    Animator anim;

    SpriteRenderer spriteNinja;
    public float Velocidad;
    public float fuerzaSalto;
    Rigidbody2D rb2D;
    bool estaEnPlataforma;
    bool desenfundar;

    // Start is called before the first frame update
    void Start()
    {
        desenfundar = false;
        estaEnPlataforma = false;
        anim = GetComponent<Animator>();
        spriteNinja = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
		#region
		
      
 
       
        #endregion

        ControlMovimiento();
        ControlSalto();
        ControlAtaque();
        

          
        
    }

    void ControlAtaque()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(1);
        bool presionarF = Input.GetKeyDown(KeyCode.F);
        if (estaEnPlataforma && stateInfo.IsName("idle_espada"))
        {
            Debug.Log("AtaqueMedio");

            if (presionarF)
            {
                anim.SetTrigger("ataque");
            }
            anim.SetBool("Empuñar", desenfundar); //tambien se puede usar para hacer una 
        }
        if (!estaEnPlataforma&&stateInfo.IsName("Jump_Espada"))
        {
            Debug.Log("ataqueSalto");
            if (presionarF)
            {
                anim.SetLayerWeight(2, 1);
                anim.SetTrigger("Salto_Ataque");
            }
        }
        if (stateInfo.IsName("Crouch"))
        {
            Debug.Log("CrouchDash");
            if (presionarF)
            {
                anim.SetLayerWeight(3, 1);
                anim.SetTrigger("Crouch_Dash");
                if (spriteNinja.flipX==true)
                {
                    transform.Translate(Vector3.right * -0.8f);
                }
                else
                {
                    transform.Translate(Vector3.right * 0.8f);    
                }
            }
        }
    }

    void ControlMovimiento()
    {

        bool presionarA = Input.GetKey(KeyCode.A);
        bool presionarD = Input.GetKey(KeyCode.D);
        bool PresionarS = Input.GetKey(KeyCode.S);

        if (presionarA)
        {
            anim.SetBool("EstaCaminando", presionarA); //se le puede poner A porque se cumple la condicion
            spriteNinja.flipX = true;
            transform.Translate(Vector3.left * Velocidad);

        }
        else if (presionarD)
        {
            anim.SetBool("EstaCaminando", presionarD);
            spriteNinja.flipX = false;
            transform.Translate(Vector3.right * Velocidad);
        }
        else
        {
            anim.SetBool("EstaCaminando", false);

        }
       
    
            if (PresionarS)
            {
                anim.SetBool("Crouch_Espada", true);

                Velocidad = 0;
            }
            else
            {
                anim.SetBool("Crouch_Espada", false);
            }
        

    }


    void ControlSalto()
    {

        bool presionarEspacio = Input.GetKeyDown(KeyCode.Space);

        if (estaEnPlataforma == true)
        {

            if (presionarEspacio)
            {
                anim.SetBool("Salto", true);
                rb2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                estaEnPlataforma = false;

            }
        }

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag=="Plataforma")
		{
            anim.SetBool("Salto", false);
            estaEnPlataforma = true;
            if (estaEnPlataforma)
            {
                anim.SetLayerWeight(2, 0);
            }

		}
        
    }
}

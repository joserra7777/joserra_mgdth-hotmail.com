using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEspada : MonoBehaviour
{

    Fases ActivarEspada;                        
    // Start is called before the first frame update
    void Start()
    {
        ActivarEspada = FindObjectOfType<Fases>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag=="Player")
		{
            ActivarEspada.espadaActiva = true;
            gameObject.SetActive(false); //
            
        }
        ActivarEspada.espadaActiva = true;
    }
    
}

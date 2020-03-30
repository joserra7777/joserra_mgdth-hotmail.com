/*
 * Nombre del desarrollador: Mayra Hernández Alviso
 * Materia: Programación orientada a objectos
 * Profesor: Josue Rivas Dias
 * Descripción general:poder cambiar las capas  de animación 

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fases : MonoBehaviour
{
//funciona como variable que agrega logica para activar o descativar las fases de 
//animacion del personaje
    public GameObject[] personaje;
    public bool espadaActiva;
    Animator player;
    // Start is called before the first frame update
    void Start()
    {
        //espadaActiva = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool DescartarEspada = Input.GetKeyDown(KeyCode.J);
        if (espadaActiva)
        {
            player.SetLayerWeight(1, 1);
            //personaje[0].SetActive(false);
            //personaje[1].SetActive(true);
            //personaje[1].transform.position = personaje[0].transform.position; // marca que se le asigne a ninja la posicion de la espada para que la tome por la posicion de la espada

        }

        else
        {
            player.SetLayerWeight(1, 0);
        }
		if (DescartarEspada)
		{
            espadaActiva = false;
            //personaje[0].SetActive(true);
            //personaje[1].SetActive(false);
            //espadaActiva = false;

        }
        
    }
}

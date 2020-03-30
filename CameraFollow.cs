
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform posicionJugador; //quien se va a movee
    public Vector3 puntoDistancia; // hacia donde se va a mover
    public float VelocidadSuavizado; //a que velocidad se va a mover

    // Start is called before the first frame update
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        puntoDistancia = transform.position - posicionJugador.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nuevaposicion = posicionJugador.position + puntoDistancia; //posicion del jugador en suma de la distancia original
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, nuevaposicion, VelocidadSuavizado); //secuencia/ interpolacion. de la posicion del objecto, genera una linea imaginaria de seguimiento (crea un carril) reubica al dueño del Lerp a la nueva posicion 
        //lerp pide 3 pasos, quien, hacia donde,a que velocidad
        transform.position = posicionSuavizada;
    }
}

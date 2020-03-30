using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecucoin : MonoBehaviour
{
    public Transform playerPosition;
    public float velEnemigo;
    public float magnitudeDist;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Ninja").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(playerPosition.position.x, transform.position.y,transform.position.z);
        float distancia = Vector3.Distance(transform.position, playerPos);
        Vector3 direccion = playerPos - transform.position;
        if (direccion.magnitude < magnitudeDist)
        {
            
            transform.LookAt(playerPosition);
            transform.Translate(Vector3.left * velEnemigo * Time.deltaTime);
        }

    }
}
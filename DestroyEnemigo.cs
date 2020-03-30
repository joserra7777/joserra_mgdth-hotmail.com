using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Espada")
        {
            Destroy(gameObject);
            Debug.Log("estoy muerto");
        }
    }
}

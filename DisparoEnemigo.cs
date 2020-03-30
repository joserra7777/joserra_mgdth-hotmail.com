using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform cañon;
    public Rigidbody2D bala;
    public void disparo()
    {
        Rigidbody2D balaPos = Instantiate(bala, cañon.position, cañon.rotation) as Rigidbody2D;
        balaPos.AddForce(cañon.right * -5000);
    }
}

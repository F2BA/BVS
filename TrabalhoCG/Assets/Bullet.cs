using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    Shooter shooter;

    void OnCollisionEnter(Collision other)
    {
        if(shooter = other.gameObject.GetComponent<Shooter>())
        {
            shooter.TakeDamage(3);
        }
        else {
            Destroy(other.gameObject);
        }
       
    }
}
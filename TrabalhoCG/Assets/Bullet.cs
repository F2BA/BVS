using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    Shooter shooter;
    public int damage;

    void OnCollisionEnter(Collision other)
    {
        if(shooter = other.gameObject.GetComponent<Shooter>())
        {
            shooter.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else {
            Destroy(other.gameObject);
        }
       
    }
}
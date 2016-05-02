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
        }
        else {
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
    }
}
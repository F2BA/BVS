using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    Shooter shooter;
    public int damage;
    public string type;
    public GameObject explosion;

    void OnCollisionEnter(Collision other)
    {
        if(shooter = other.gameObject.GetComponent<Shooter>())
        {
            if(type == "ray" || type == "bomb")
            {
                Transform trans = other.transform;
                GameObject instance = Instantiate(explosion, trans.position, trans.rotation) as GameObject;
            }
            shooter.TakeDamage(damage);
        }
        else {
            if (!other.gameObject.CompareTag("IgnoreCollision")) Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
    }
}
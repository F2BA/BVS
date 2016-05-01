using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletRef;
    public float bulletSpeed;
    public KeyCode shootKey;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(shootKey))
        {
            GameObject instance = Instantiate(bullet, bulletRef.transform.position, bulletRef.transform.rotation) as GameObject;
            Rigidbody bulletRigidbody = instance.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(instance.transform.forward * bulletSpeed);
            }
        }


    }
}
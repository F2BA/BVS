using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    private int defeats = 0;

    public int life;
    public int maxLife;
    public Texture lifeTexture;
    private int lifeboxSize;

    public GameObject bullet;
    public GameObject bulletRef;
    public float bulletSpeed;
    public KeyCode shootKey;

    // Use this for initialization
    void Start()
    {
        lifeboxSize = 625;
    }

    public void TakeDamage(int damage)
    {
        if ((life - damage) <= 0)
        {
            defeats = defeats + 1;
            //TODO: colocar efeito de explosão e eventualmente resetar o jogo para as posições iniciais
            life = maxLife;
        }
        else {
            life = life - damage;
        }
        lifeboxSize = (625 * life) / maxLife;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(25, 25, lifeboxSize, 30), lifeTexture);
        GUI.Label(new Rect(25, 70, 100, 30), "Defeats: "+defeats);
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
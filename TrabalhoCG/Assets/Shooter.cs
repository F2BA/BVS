using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public int playerNumber = 1;
    private int screenStart;

    private int defeats = 0;

    private int life;
    public int maxLife;
    public Texture lifeTexture;
    private int lifeboxSize;

    public GameObject bullet;
    public GameObject bulletRef;
    public float bulletSpeed;
    public KeyCode shootKey;

    public GameObject bomb;
    public float bombSpeed;
    public KeyCode bombKey;

    // Use this for initialization
    void Start()
    {
        life = maxLife;
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
        screenStart = (Screen.width / 2) * (playerNumber - 1);
        GUI.Box(new Rect(screenStart + 25, 25, lifeboxSize, 30), lifeTexture);
        GUI.Label(new Rect(screenStart + 25, 70, 100, 30), "Defeats: "+defeats);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(bombKey) && playerNumber == 1)
        {
            GameObject instance = Instantiate(bomb, bulletRef.transform.position, bulletRef.transform.rotation) as GameObject;
            Rigidbody bombRigidbody = instance.GetComponent<Rigidbody>();
            if (bombRigidbody != null)
            {
                bombRigidbody.AddForce((instance.transform.forward * bombSpeed) + (instance.transform.up * bombSpeed));
            }
        }

        if (Input.GetKeyUp(shootKey))
        {
            GameObject instance = Instantiate(bullet, bulletRef.transform.position, bulletRef.transform.rotation) as GameObject;
            Rigidbody bulletRigidbody = instance.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                if(playerNumber == 1) bulletRigidbody.AddForce(instance.transform.forward * bulletSpeed);
                else if (playerNumber == 2) bulletRigidbody.AddForce(instance.transform.up * bulletSpeed);
            }
        }


    }
}
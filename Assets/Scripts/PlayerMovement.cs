using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject PlayerBullet;
    public GameObject PlayerBulletPosition01;
    public GameObject PlayerBulletPosition02;

    public AudioSource bulletSound;

    public float maxSpeed = 3f;
    public float rotSpeed = 180f;
    public float playerBoundaryRadius = 0.5f;

    [SerializeField]
    private BarStat healthBar;
    private NewBehaviourScript myHealth;
    private Animator animator;

    private void Awake()
    {
        myHealth = GetComponent<NewBehaviourScript>();
        healthBar.bar = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<BarScript>();
        healthBar.Initialize();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        healthBar.MaxVal = myHealth.maxHealth;
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.CurrentVal = myHealth.healt;

        if (myHealth.healt <= 0)
        {
            HandelDeath();
            return;
        }

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        pos += rot * velocity;

        if (pos.y + playerBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - playerBoundaryRadius;
        }
        if (pos.y - playerBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + playerBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + playerBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - playerBoundaryRadius;
        }
        if (pos.x - playerBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + playerBoundaryRadius;
        }

        transform.position = pos;

        if (Input.GetKeyDown("space"))
        {

            GameObject bullet01 = (GameObject)Instantiate(PlayerBullet);
            bullet01.transform.position = PlayerBulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBullet);
            bullet02.transform.position = PlayerBulletPosition02.transform.position;

            if (bulletSound != null)
            {
                bulletSound.Play();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            myHealth.healt -= 5;
            Destroy(collision.gameObject);
            Debug.Log("Enemy bullet hit the Player!");

        }
    }

    private void HandelDeath()
    {
        if (animator != null)
        {
            animator.SetBool("playerdie", true);
        }
        Destroy(gameObject, 1f);
    }
}

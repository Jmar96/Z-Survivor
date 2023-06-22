using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Transform shootingPoint;
    public GameObject bullet;
    public float bulletSpeed;
    [SerializeField]
    Text playerHPTxtBox;

    Vector2 moveDirection;

    public VariableJoystick joystick;
    private Animator anim;
    float x;
    float y;
    string WALK_ANIMATION = "Walk";
    string ENEMY_TAG = "Enemy";
    float playerLife = 100;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        Shoot();
        AnimatePlayer();
        PlayerDied();
        IsPlayerDead();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void MyInput()
    {
        x = joystick.Horizontal; //Input.GetAxis("Horizontal");
        y = joystick.Vertical; //Input.GetAxis("Vertical");

        moveDirection = new Vector2(x, y);
    }
    void Movement()
    {
        rb.velocity = moveDirection * speed;

        if (rb.velocity != Vector2.zero)
        {
            transform.up = rb.velocity;
        }
    }
    void Shoot()
    {
        if(Input.mousePosition.x >= Screen.width / 2)
        {
            //right screen touch
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                GameObject bulletClone = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
                Rigidbody2D bulletRigidBody = bulletClone.GetComponent<Rigidbody2D>();
                bulletRigidBody.AddForce(shootingPoint.up * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        else
        {
            //left screen touch
            //Debug.Log("left screen touch");
        }
    }
    void AnimatePlayer()
    {
        if (x != 0 || y != 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if zombie hit by bullet
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            if (playerLife >= 1)
            {
                playerLife = playerLife - 40;
                playerHPTxtBox.text = playerLife.ToString();
            }
            else
            {
                SceneManager.LoadScene("RetryScene");
                Debug.Log("Player Died!");
            }
        }
        //if 
    }
    void PlayerDied()
    {
        if (playerLife <= 0)
        {
            anim.SetBool("Dead", true);
        }
        else
        {
            anim.SetBool("Dead", false);
        }
    }
    void IsPlayerDead()
    {
        if (playerLife <= 0)
        {
            playerLife = 0;
            playerHPTxtBox.text = playerLife.ToString();
            //Time.timeScale = 0;
            SceneManager.LoadScene("RetryScene");
        }
    }
}

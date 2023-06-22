using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float speed;
    public float distanceBetween;

    private float distance;
    private GameObject player;
    private string Bullet_TAG = "Bullet";
    private float zombieLife = 100;

    ScoreManager scoreManager;
    GameObject scoreMgr;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/Player");

        //score manager
        scoreMgr = GameObject.Find("/Score Manager");
        scoreManager = scoreMgr.GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if zombie hit by bullet
        if (collision.gameObject.CompareTag(Bullet_TAG))
        {
            if (zombieLife >= 1)
            {
                zombieLife = zombieLife - WeaponData.weapon01;
                Destroy(collision.gameObject);
                Debug.Log("Zombie Life : " + zombieLife);
            }
            else
            {
                Debug.Log("Zombie Dead!");
                scoreManager.AddScore();
                Destroy(this.gameObject);
            }
        }
        //if 
    }
}

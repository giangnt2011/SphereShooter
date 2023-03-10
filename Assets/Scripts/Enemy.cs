using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const string playerTag = "Player";
    const string bulletTag = "Bullet";
    public float minSpeed = 1.0f;
    public float maxSpeed = 6.0f;
    
    public int health = 1;
    public int damageToCause = 1;

    float speed;
    GameObject player;
    public GameObject enemyExplosionPrefab;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed) + (Time.time / 25);
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag(playerTag);
    }

    void FixedUpdate()
    {
        if (player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag(bulletTag))  {
            Destroy(col.gameObject);
            ScoreManager.scoreManager.IncreaseScore(1);
            health--;
        }
        if (col.gameObject.CompareTag(playerTag))  {
            HealthManager.instance.ChangeHealth(-damageToCause);
            DestroyEnemy();
        }

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }
    void DestroyEnemy()
    {
        GameObject explosionInstance = Instantiate(enemyExplosionPrefab, transform.position, new Quaternion(0,1,1,1));
        Destroy(explosionInstance, 5.0f);
        audioSource.Play();
        Transform trailRenderer = transform.GetChild(0);
        if (trailRenderer)
        {
            trailRenderer.parent = null;
            Destroy(trailRenderer.gameObject, trailRenderer.GetComponent<TrailRenderer>().time);
        }
        Destroy(this.gameObject);
    }
}

EnemyFollower -> follow.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField] private float timer = 4;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;

        bulletTime = timer;

        // Instantiate the bullet prefab
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);

        // Get a reference to the BulletScript on the instantiated bullet object
        BulletScript bulletScript = bulletObj.GetComponent<BulletScript>();

        // Set the spawnPoint variable for the bullet
        if (bulletScript != null)
        {
            bulletScript.spawnPoint = spawnPoint;
        }

        // Additional setup for the bullet (if needed)

        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletObj.transform.forward * enemySpeed * 10);
        /*Destroy(bulletObj, 5f);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Handle player collision if needed
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
           /* GameManager.health -= 1;*/
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField]
    private GameObject laserPrefab;

    private float fireRare = 0.5f;

    private float nextFire = 0.0f;

    private int hp = 3;

    private SpawnManagerController spawnManager;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManagerController>();
        if(spawnManager == null ) {
            Debug.Log("Spawn Null");
        }
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        FireLaser();
        
    }
    
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        direction = direction.normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.x > 9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);

        }
        if (transform.position.x < -9)
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, 6, transform.position.z);

        }
        if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }
    }
    
    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRare;
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }
    public void TakeDamage()
    {
        hp--;
        Debug.Log(hp);
        if (hp < 1)
        {
            spawnManager.OnPlayerDead();
            Destroy(this.gameObject);
        }
    }
}

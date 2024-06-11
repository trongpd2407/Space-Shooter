using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;
    private float speedBoost = 2f;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField]
    private GameObject laserPrefab;

    [SerializeField]
    private GameObject tripleShotPrefab;

    [SerializeField]   
    private GameObject shieldPrefab;

    private float fireRare = 0.5f;

    private float nextFire = 0.0f;

    private int hp = 3;
    [SerializeField]
    private bool tripleShotIsActives = false;

    [SerializeField]
    private bool speedBoostIsActive = false;

    [SerializeField]
    private bool shieldIsActive = false;

    [SerializeField]
    private int score = 0;

    private SpawnManagerController spawnManager;

    private UIManager uiManager;
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
        //Checking speed powerup
        if(speedBoostIsActive )
        {
            transform.Translate(direction * speed * speedBoost * Time.deltaTime);
        }else transform.Translate(direction * speed * Time.deltaTime);

        // checking out of bound
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
            if(tripleShotIsActives == false)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(tripleShotPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }
        }
    }
    public void TakeDamage()
    {
        if (shieldIsActive == true)
        {
            shieldIsActive = false;
            StopCoroutine(StopShieldPowerUp());
            Destroy(transform.Find("Shield(Clone)").gameObject);
        }
        else hp--;
        uiManager.UpdateLiveSprite(hp);
        if (hp < 1)
        {
            spawnManager.OnPlayerDead();
            Destroy(this.gameObject);
        }
       
    }

    public void TripleShotActive()
    {
        tripleShotIsActives = true;
        StartCoroutine(StopTripleshotPowerUp());
    }
    public void SpeedBoostActive()
    {
        speedBoostIsActive = true;
        StartCoroutine(StopSpeedPowerUp());
    }

    public void ShieldActive()
    {
        shieldIsActive = true;
        GameObject shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        shield.transform.parent = this.transform;
        StartCoroutine(StopShieldPowerUp());
    }

    IEnumerator StopTripleshotPowerUp()
    {
        yield return new WaitForSeconds(5f);
        tripleShotIsActives = false;
    }
    IEnumerator StopSpeedPowerUp()
    {
        yield return new WaitForSeconds(5f);
        speedBoostIsActive = false;
    }
    IEnumerator StopShieldPowerUp()
    {
        yield return new WaitForSeconds(5f);
        if (shieldIsActive)
        {
            Destroy(transform.Find("Shield(Clone)").gameObject);
        }
        shieldIsActive = false;
        
    }
    public void AddScore(int point)
    {
        score += point;
        uiManager.UpdateScore(score);
    }

}

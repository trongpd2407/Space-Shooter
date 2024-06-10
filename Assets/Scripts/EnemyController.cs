using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;


    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -5f)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX,8f,0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.GetComponent<PlayerController>().TakeDamage();
 
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

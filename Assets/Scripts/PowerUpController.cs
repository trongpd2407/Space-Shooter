using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {

        transform.Translate(Vector3.down * speed* Time.deltaTime);
        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") ){
            collision.transform.GetComponent<PlayerController>().GetPowerUp();
            Destroy(this.gameObject);
        }
    }
}

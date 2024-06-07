using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private float speed = 5f;
 
    // id : triple shot = 0, speed =1, shield = 2
    [SerializeField]
    private int powerUpId;
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
            PlayerController playerController = collision.transform.GetComponent<PlayerController>();
            switch (powerUpId)
            {
                case 0:
                    playerController.TripleShotActive();

                    break;
                case 1:
                    playerController.SpeedBoostActive();
                    break;
                case 2:
                    Debug.Log("Shield");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}

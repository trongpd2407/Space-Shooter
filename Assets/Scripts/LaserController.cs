using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);   

        if(transform.position.y > 7)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}

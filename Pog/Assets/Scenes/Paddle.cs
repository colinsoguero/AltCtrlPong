using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPaddle1;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaddle1)
        {
            transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
            if(transform.position.y > 4.25f)
                transform.position = new Vector3(-10f, 4.25f, 0f);
            if(transform.position.y < -4.25f)
                transform.position = new Vector3(-10f, -4.25f, 0f);
        }
        else
        {
            transform.Translate(0f, Input.GetAxis("Vertical2") * speed * Time.deltaTime, 0f);
            if(transform.position.y > 4.25f)
                transform.position = new Vector3(10f, 4.25f, 0f);
            if(transform.position.y < -4.25f)
                transform.position = new Vector3(10f, -4.25f, 0f);
        }

    }
}

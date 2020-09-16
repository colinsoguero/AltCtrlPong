using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPaddle1;
    public GameObject mic;
    public MicInput micPos;
    public AudioSource clip;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        micPos = mic.GetComponent<MicInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(micPos.scaledPos);
        if(isPaddle1)
        {
            transform.Translate(0f, micPos.scaledPos2 * Time.deltaTime, 0f);
            //transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
            if(transform.position.y > 4.25f)
                transform.position = new Vector3(-10f, 4.25f, 0f);
            if(transform.position.y < -4.25f)
                transform.position = new Vector3(-10f, -4.25f, 0f);
        }
        else
        {
            transform.Translate(0f, micPos.scaledPos1 * Time.deltaTime, 0f);
            //Vector3 paddle2Pos = new Vector3(10f, micPos.scaledPos, 0f);
            //transform.position = paddle2Pos;
            //transform.Translate(0f, Input.GetAxis("Vertical2") * speed * Time.deltaTime, 0f);
            if(transform.position.y > 4.25f)
                transform.position = new Vector3(10f, 4.25f, 0f);
            if(transform.position.y < -4.25f)
                transform.position = new Vector3(10f, -4.25f, 0f);
        }

    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            clip.Play();
        }
    }
}

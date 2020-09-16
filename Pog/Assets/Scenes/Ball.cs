using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 5f;
    public float factor = 1.02f;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(startSpeed * sx, startSpeed * sy, 0f);
        originalPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        //speed += .5f;
    }
    public void ResetPosition()
    {
        GetComponent<Rigidbody>().velocity *= factor;
        transform.position = originalPosition;
    }
}

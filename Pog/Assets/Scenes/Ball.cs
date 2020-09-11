using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, speed * sy, 0f);
        originalPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}

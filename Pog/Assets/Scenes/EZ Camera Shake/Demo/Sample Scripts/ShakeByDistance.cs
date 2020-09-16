using UnityEngine;
using EZCameraShake;

public class ShakeByDistance : MonoBehaviour
{
    public GameObject paddle1, paddle2;

    public float heightMax = 8.5f;
    private float p1Height, p2Height, avgHeight;

    //Our saved shake instance.
    private CameraShakeInstance _shakeInstance;

    void Start()
    {
        //Create the shake instance. We will modify its properties in Update()
        _shakeInstance = CameraShaker.Instance.StartShake(2, 14, 0);
        

    }

	void Update ()
    {
        p2Height = paddle2.GetComponent<Paddle>().transform.position.y + 4.25f;
        p1Height = paddle1.GetComponent<Paddle>().transform.position.y + 4.25f;
        avgHeight = (p1Height+p2Height)/2;
        //Debug.Log(p2Height);
        _shakeInstance.ScaleMagnitude = Mathf.Clamp01(avgHeight / heightMax)*1.5f;
	}
}

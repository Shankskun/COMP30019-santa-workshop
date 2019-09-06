using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    // camera shaking reference from : https://gist.github.com/ftvs/5822103;

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0.5f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float timer;
    private static bool toShake;
    private const float SHAKE_AMOUNT  = 0.5f;
    private const float DECREASE_FACT = 1.0f;


    // original position of camera
    Vector3 originalPos;

    // get transform component of camera
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    // get orginal camera position, and reset timer
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
        timer = shakeDuration;
    }

    void Update()
    {
        if (toShake == true)
        {
            // shake
            if (timer > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * SHAKE_AMOUNT;
                timer -= Time.deltaTime * DECREASE_FACT;
            }
            // stop shaking
            else
            {
                timer = shakeDuration;
                camTransform.localPosition = originalPos;
                toShake = false;
            }
        }
    }

    // enable shaking when box is burnt
    public static void Shake()
    {
        toShake = true;
    }
}

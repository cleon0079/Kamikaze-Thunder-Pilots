using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherRotation : MonoBehaviour
{
    [SerializeField] private bool rotateRight;
    [SerializeField] private bool startNextRotation = true;
    [SerializeField] private float rotateAngle;
    [SerializeField] private float secondsToRotate;

    [SerializeField] private float secondsToWait = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(startNextRotation && rotateRight)
        {
            StartCoroutine(Rotate(rotateAngle,secondsToRotate));
        }
        else if(startNextRotation && !rotateRight)
        {
            StartCoroutine(Rotate(-rotateAngle,secondsToRotate));

        }
        
    }

    IEnumerator Rotate(float _rotateAngle, float _duration)
    {
        startNextRotation = false;
        
        Quaternion initialRotation = transform.rotation;

        float timer = 0f;

        while(timer < _duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / _duration * _rotateAngle, Vector3.forward);
            yield return null;
        }

        yield return new WaitForSeconds(secondsToWait);

        startNextRotation = true;
        rotateRight = !rotateRight;
    }
    
}

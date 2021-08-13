using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherRotation : MonoBehaviour
{
    [Header("Rotation Variables")]
    [SerializeField] private bool rotateRight;
    [SerializeField] private bool startNextRotation = true;
    [SerializeField] private float rotateAngle;
    [SerializeField] private float secondsToRotate;
    [SerializeField] private float secondsToWait = 1f;
    [SerializeField] private bool rotate360 = false;

    [Header("Movement Variables")] 
    [SerializeField] private Transform parent;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool move = false;

    
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

        if(rotate360 && rotateRight)
        {
            StartCoroutine(Rotate360(rotateAngle, secondsToRotate));
        }
        else if(rotate360 && !rotateRight)
        {
            StartCoroutine(Rotate360(-rotateAngle, secondsToRotate));

        }
    }

    /// <summary>
    /// Coroutine for rotating the object
    /// </summary>
    /// <param name="_rotateAngle">Angle of rotation</param>
    /// <param name="_duration">Time in seconds rotation takes</param>
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
    
    /// <summary>
    /// Coroutine for rotating a specifed amount of degrees.
    /// </summary>
    /// <param name="_rotateAngle">The angle to rotate</param>
    /// <param name="_duration">Amount of time the rotation takes in seconds</param>
    IEnumerator Rotate360(float _rotateAngle, float _duration)
    {
        Quaternion initialRotation = transform.rotation;

        float timer = 0f;

        while(timer < _duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / _duration * _rotateAngle, Vector3.forward);
            yield return null;
        }

        yield return new WaitForSeconds(secondsToWait);
        
    }
    
}

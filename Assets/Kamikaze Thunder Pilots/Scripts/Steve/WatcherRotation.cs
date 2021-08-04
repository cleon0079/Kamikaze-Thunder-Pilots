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

    [Header("Movement Variables")] 
    [SerializeField] private Transform parent;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool move = false;

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

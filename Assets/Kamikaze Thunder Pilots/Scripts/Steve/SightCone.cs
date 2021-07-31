using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCone : MonoBehaviour
{
    private EdgeCollider2D sightCollider;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    
    // Start is called before the first frame update
    void Start()
    {
        sightCollider = GetComponent<EdgeCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D _collider)
    {
        Debug.Log("trigger");
        if(_collider.gameObject.tag == "Player")
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D _collider)
    {
        Debug.Log("triggerExit");
        if(_collider.gameObject.tag == "Player")
        {
            spriteRenderer.color = originalColor;
        }
    }
}

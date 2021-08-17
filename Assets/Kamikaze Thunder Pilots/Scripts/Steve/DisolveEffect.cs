using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveEffect : MonoBehaviour
{
    private Material material;

    private bool isDissolving = false;
    private float fade = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }

        if(isDissolving)
        {
            fade -= Time.deltaTime;

            if(fade <= 0)
            {
                fade = 0;
                isDissolving = false;
            }
            
            material.SetFloat("_Fade", fade);
        }
        
    }
}

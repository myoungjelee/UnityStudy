using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;
    
    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
   
    void Update()
    {
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
       // transform.Translate(new Vector3(2 * width, 0, 0));
        transform.position = transform.position + new Vector3(2* width, 0, 0);
    }
}

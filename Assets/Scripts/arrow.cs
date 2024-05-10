using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
  
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Vector2 direction;

    // Start is called before the first frame update
    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        
    }
    private void FixedUpdate()
    {
       // _rigidbody2D.AddForce(direction*30);
    }
}

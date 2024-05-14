using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;


    public Action OnMouseLeftPressed;
    public Action OnMouseLeftRelease;

    private Vector3 _mouseWorldPosition;
    
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else if (instance == this)
        { 
            Destroy(gameObject);
        }
    }

    private Vector3 _mousePositionInWorld;
    [SerializeField] private Camera _mainCamera;
   

    // Update is called once per frame
    private void Update()
    {
      

        if(Input.GetMouseButtonDown(0))
        {
            OnMouseLeftPressed?.Invoke();
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseLeftRelease?.Invoke();
           // PiuPiu = true;
        }


       
       _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        

    }



    
    public Vector3 InputMousePosition()
    {
       return _mouseWorldPosition;

    }
}

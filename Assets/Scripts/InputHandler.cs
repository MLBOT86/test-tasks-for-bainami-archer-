using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;


    public Action OnMouseLeftPressed;
    public Action OnMouseLeftRelease;

    private Vector3 mouseWorldPosition;
    //The shot was fired
    public bool PiuPiu = false;
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
    [SerializeField] private Transform _playerTransform;

    // Update is called once per frame
    private void Update()
    {
        float enter;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward,_playerTransform.position).Raycast(ray, out enter);
        _mousePositionInWorld = ray.GetPoint(enter);

        if(Input.GetMouseButtonDown(0))
        {
            OnMouseLeftPressed?.Invoke();
           // Debug.Log(mouseWorldPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseLeftRelease?.Invoke();
            PiuPiu = true;
        }


       // Debug.Log( _mainCamera.ScreenToWorldPoint(Input.mousePosition));
       mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

    }



    
    public Vector3 InputMousePosition()
    {
       return _mousePositionInWorld;

    }
}

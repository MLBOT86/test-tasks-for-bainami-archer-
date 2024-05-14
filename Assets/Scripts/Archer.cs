using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;


public class Archer : MonoBehaviour
{
    [SerializeField] UnityEngine.Transform _archerPosition;

   
    [SerializeField] private BowOption _bow;
    
    [SerializeField] GameObject _shellSpawnPoint;
    

    private float _startPowerShot;
    private float _maxPowerShot;
    private float _curentPowerShot;
    private bool _chargingShot= false;





    private Vector3 _mousePositionInWorld;
    private float _angle;
    private float PosX;
    private float PosY;
    private void Start()
    {
        InputHandler.instance.OnMouseLeftPressed += ChargingShot;
        

        _startPowerShot = _bow.StartPower;
       
        _maxPowerShot = _bow.MaxPower;
        InputHandler.instance.OnMouseLeftRelease += SpawnShell;
       
    }
    private void Update()
    {
        GetMousePosition();
        RotateArcherPosition(_mousePositionInWorld);
     
    }
    private void FixedUpdate()
    {
        if(_chargingShot)
        {
           StartOfShooting();
         
        }
       
    }

    private void ChargingShot()
    {
        _curentPowerShot = _startPowerShot;
        _chargingShot = true;
       
      
    }
    private void StartOfShooting()
    {
        
        if(_curentPowerShot < _maxPowerShot)
        {
            _curentPowerShot = _curentPowerShot + 0.2f;
        }
        else
        {
            _curentPowerShot = _maxPowerShot;
            _chargingShot = false;
        }
    }


    private void GetMousePosition()
    {
        _mousePositionInWorld =  InputHandler.instance.InputMousePosition();

    }

    private void RotateArcherPosition(Vector3 mousePosition)
    {
        
        Vector3 _direction = (mousePosition - _archerPosition.position);
        _direction.z = 0f;
        _direction.Normalize();
      
        PosX = _direction.x;
        PosY = _direction.y;

        //The formula is used here
        // float angle = Mathf.Atan2(posY, posX) * Mathf.Rad2Deg;
        _angle = ProjectMath.GetAngleRotation(_direction.y, _direction.x);
      
        _archerPosition.rotation = Quaternion.Euler(0f, 0f, _angle);

       
      
       

    }
    public Vector3 GetRotationPosition()
    {
         Vector3 speed = new Vector3(PosX, PosY, 0) *_curentPowerShot;
       
      
        return  speed;
    }

    
    
    public float GetActualAngle()
    {
        return _angle-90;
    }

    private void SpawnShell()
    {
        Rigidbody2D bullet = Instantiate(_bow.BulletPrefab,_shellSpawnPoint.transform.position, Quaternion.Euler(0f, 0f, _angle)).GetComponent<Rigidbody2D>();
        bullet.AddForce(GetRotationPosition() * _curentPowerShot, ForceMode2D.Impulse);
      
    }



  




}

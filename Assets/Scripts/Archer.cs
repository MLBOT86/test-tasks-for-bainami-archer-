using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Archer : MonoBehaviour
{
    [SerializeField] UnityEngine.Transform _archerPosition;

    // private TrajectoryCalcylation _trajectoryCalcylation;
    [SerializeField] private BowOption _bow;
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] GameObject _shellSpawnPoint;
    [SerializeField] LineRenderer _lineRenderer;

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
        //InputHandler.instance.OnMouseLeftRelease += Shooting;

        _startPowerShot = _bow.StartPower;
       
        _maxPowerShot = _bow.MaxPower;
        InputHandler.instance.OnMouseLeftRelease += SpawnShell;
        // _trajectoryCalcylation = new TrajectoryCalcylation(0f,transform.position,Vector3.zero);
    }
    private void Update()
    {
        GetMousePosition();
        RotateArcherPosition(_mousePositionInWorld);
        ShowTrajectory(_archerPosition.position, GetRotationPosition());

    }
    private void FixedUpdate()
    {
        if(_chargingShot)
        {
           StartOfShooting();
           Debug.Log("pow" + _curentPowerShot);
        }
       
    }

    private void ChargingShot()
    {
        _curentPowerShot = _startPowerShot;
        _chargingShot = true;
        _lineRenderer.enabled = true;
      
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
        // Debug.Log(mousePosition);
        Vector3 _direction = (mousePosition - _archerPosition.position);
        _direction.z = 0f;
        _direction.Normalize();
        Debug.Log(_direction);
        PosX = _direction.x;
        PosY = _direction.y;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        // Debug.Log(_angle);
        _archerPosition.rotation = Quaternion.Euler(0f, 0f, _angle);

       
        // Debug.Log(direction);
       

    }
    public Vector3 GetRotationPosition()
    {
         var speed = new Vector3(PosX, PosY, 0) *_curentPowerShot;
       
      //  var getPoint = TrajectoryCalcylationNew.GetPositiontTrajectory(1f, transform.position, speed);
       // Debug.Log(getPoint);
        return  speed;
    }
    
    
    public float GetActualAngle()
    {
        return _angle-90;
    }

    private void SpawnShell()
    {
        Rigidbody2D bullet = Instantiate(_arrowPrefab,_shellSpawnPoint.transform.position, Quaternion.Euler(0f, 0f, _angle)).GetComponent<Rigidbody2D>();
        bullet.AddForce(GetRotationPosition() * _curentPowerShot, ForceMode2D.Impulse);
       _lineRenderer.enabled= false;
    }



    public void ShowTrajectory(Vector3 startPosition, Vector3 speed)
    {
        Vector3[] points= new Vector3[5];
        _lineRenderer.positionCount=points.Length;
       
        for (int i = 0; i < points.Length; i++)
        {
            float time =0.05f+ i * 0.2f;
            points[i] = TrajectoryCalcylationNew.GetPositiontTrajectory(time, startPosition, speed);
        }
        _lineRenderer.SetPositions(points);
    }




}

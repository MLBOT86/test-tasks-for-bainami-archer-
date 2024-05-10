using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Archer : MonoBehaviour
{
    [SerializeField] GameObject _archerHand;

   // private TrajectoryCalcylation _trajectoryCalcylation;
    private Vector3 _mousePositionInWorld;
    private float _angle;
    private float PosX;
    private float PosY;
    private void Start()
    {
       // _trajectoryCalcylation = new TrajectoryCalcylation(0f,transform.position,Vector3.zero);
    }
    private void Update()
    {
        GetMousePosition();
        RotateArcherHand(_mousePositionInWorld);

       
    }

    private void GetMousePosition()
    {
        _mousePositionInWorld =  InputHandler.instance.InputMousePosition();

    }

    private void RotateArcherHand(Vector3 mousePosition)
    {
        // Debug.Log(mousePosition);
        Vector3 _direction = (mousePosition - _archerHand.transform.position);
        PosX = _direction.x;
        PosY = _direction.y;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        // Debug.Log(_angle);
        _archerHand.transform.rotation = Quaternion.Euler(0f, 0f, _angle + 90);

       
        // Debug.Log(direction);
       

    }
    public Vector2 GetHandRotation()
    {
         var speed = new Vector3(PosX, PosY, 0) * 2;
       
        var getPoint = TrajectoryCalcylationNew.GetPositiontTrajectory(1f, transform.position, speed);
        Debug.Log(getPoint);
        return new Vector2(PosX, PosY);
    }
    
    public Quaternion NewArcherHandPosition()
    {
        return Quaternion.Euler(0f, 0f, _angle-90);
    }
    public float GetActualAngle()
    {
        return _angle-90;
    }



}

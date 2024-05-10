using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryCalcylation
{

    private float _timePosition;
    private Vector3 _startPosition;
    private Vector3 _speed;
    private Vector3 _pointPosition;
    

    public TrajectoryCalcylation(float timePosition,Vector3 startPosition, Vector3 speed) {
    this._timePosition = timePosition;
    this._startPosition = startPosition;
    this._speed = speed;
    
    }

    private void Calcylation()
    {

        _pointPosition = _startPosition + _speed * _timePosition + Physics.gravity * _timePosition * _timePosition / 2f;
    }

    public Vector3 GetPositiontTrajectory()
    {
        Calcylation();
        return _pointPosition;
    }

}

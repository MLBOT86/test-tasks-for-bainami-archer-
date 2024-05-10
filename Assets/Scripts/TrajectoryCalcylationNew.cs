using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrajectoryCalcylationNew 
{


    public static Vector3 GetPositiontTrajectory(float timePosition, Vector3 startPosition, Vector3 velosity)
    {

       Vector3 pointPosition = startPosition + velosity * timePosition + Physics.gravity * timePosition * timePosition / 2f;


        return pointPosition;
    }

}

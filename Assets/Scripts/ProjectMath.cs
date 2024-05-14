using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectMath
{


    public static Vector3 GetPositiontTrajectory(float timePosition, Vector3 startPosition, Vector3 velosity)
    {

       Vector3 pointPosition = startPosition + velosity * timePosition + Physics.gravity * timePosition * timePosition / 2f;


        return pointPosition;
    }
    public static float GetAngleRotation(float posY,float posX)
    {

         float angle = Mathf.Atan2(posY, posX) * Mathf.Rad2Deg;

        return angle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform[] WayPoints;
    public Transform SelfTransform;
    public CarMover Car;
    private int _currentPoint=0;
    void Update()
    {
        Transform current = WayPoints[_currentPoint];
        Vector3 direction = SelfTransform.position - current.position;
        float angel = Vector3.Dot(direction, -SelfTransform.right);
        if (angel>0)
            Car.RotateRight();
        else
        if (angel == 0)
        {
        }
        else
            Car.RotateLeft();

        if (angel<0.2f && angel>-0.2f)
        {
            Car.Accelerate();
        }
        if (Vector3.Distance(SelfTransform.position, current.position) < 1f)
        {
            _currentPoint++;
            if (_currentPoint>WayPoints.Length)
                _currentPoint = 0;
            if (_currentPoint==25)
                _currentPoint = 0;
        }
    }
}

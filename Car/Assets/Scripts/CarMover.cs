using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CarMover : MonoBehaviour
{
    public Transform SelfTransform;
    public Tilemap Map;
    public TileBase GroundTile;
    public float speed;
    private Vector3 _force;
    private bool _isAccelerated;
    public float GetForce()
    {
        return _force.magnitude;
    }
    public void Accelerate()
    {
        _force += (SelfTransform.up * Time.deltaTime) * 0.1f;
        _isAccelerated = true;
    }
    public void RotateRight()
    {
        SelfTransform.Rotate(0,0,-1);

    }
    public void RotateLeft()
    {
        SelfTransform.Rotate(0,0,1);
    }
    void LateUpdate()
    {
        if (!_isAccelerated)
            _force = Vector3.Lerp(_force, Vector3.zero, Time.deltaTime);
        //if (Map.GetTile(new Vector3Int((int) SelfTransform.position.x,(int) SelfTransform.position.y,(int) SelfTransform.position.z))==GroundTile)
            _force *= speed;
        SelfTransform.position += _force;
        _isAccelerated = false;
    }
}

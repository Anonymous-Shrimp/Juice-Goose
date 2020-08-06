using UnityEngine;

public class PointInTime
{

    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public float forceAmmt;
    public Sprite sprite;

    public PointInTime(Vector3 _position, Quaternion _rotation, Vector3 _velocity, float _forceAmmt, Sprite _sprite)
    {
        position = _position;
        rotation = _rotation;
        velocity = _velocity;
        forceAmmt = _forceAmmt;
        sprite = _sprite;
    }

}
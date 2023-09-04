using System;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    private Transform _myTransform;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _myTransform = transform;
    }

    void Update()
    {
        var direction = GetDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (_speed * Time.deltaTime));
        ClampFinalPosition();
    }

    private void ClampFinalPosition()
    {
        var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
        viewportPoint.x = Math.Clamp(viewportPoint.x, 0.03f, 0.97f);
        viewportPoint.y = Math.Clamp(viewportPoint.y, 0.03f, 0.97f);
        _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }

    private Vector2 GetDirection()
    {
        
        return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        var horizontalDir = Input.GetAxis("Horizontal");
        var verticalDir = Input.GetAxis("Vertical");
        return new Vector2(horizontalDir, verticalDir);
    }
}

using Ships;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed;
    private IInput _input;
    private Transform _myTransform;
    private ICheckLimits _checkLimits;

    private void Awake()
    {
        _myTransform = transform;
    }
    
    public void Configure(IInput input, ICheckLimits checkLimits)
    {
        _input = input;
        _checkLimits = checkLimits;
    }

    void Update()
    {
        var direction = GetDirection();
        print(Camera.main.WorldToViewportPoint(transform.position));

        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (speed * Time.deltaTime));
        _checkLimits.ClampFinalPosition();
    }

    private Vector2 GetDirection()
    {
        return _input.GetDirection();
    }
}

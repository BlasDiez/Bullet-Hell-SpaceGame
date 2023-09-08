using Ships;
using Ships.Weapon;
using UnityEngine;
using UnityEngine.Serialization;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float firerateInSeconds;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileSpawnPosition;
    
    private IInput _input;
    private ICheckLimits _checkLimits;
    private Transform _myTransform;
    private float _remainingSecondsToBeAbleToShoot;
    
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
        Move(direction);
        TryShoot();
    }

    private void TryShoot()
    {
        _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
        if (_remainingSecondsToBeAbleToShoot > 0)
        {
            return;
        }

        if (_input.IsFireActionPressed())
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        _remainingSecondsToBeAbleToShoot = firerateInSeconds;
        Instantiate(projectilePrefab, projectileSpawnPosition.position, projectileSpawnPosition.rotation);
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

using Ships;
using Ships.Weapon;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(WeaponController))]

public class ShipMediator : MonoBehaviour, IShip
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private MovementController movementController;
    
    private IInput _input;
    
    public void Configure(IInput input, ICheckLimits checkLimits)
    {
        _input = input;
        movementController.Configure(this, checkLimits);
        weaponController.Configure(this, checkLimits);
    }

    void Update()
    {
        var direction = _input.GetDirection();
        movementController.Move(direction);
        TryShoot();
    }

    private void TryShoot()
    {
        if (_input.IsFireActionPressed())
        {
            weaponController.TryShoot();
        }
    }
}

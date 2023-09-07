using Ships;
using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    [SerializeField] private bool useAI;
    [SerializeField] private bool useJoystick;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Ship ship;
    
    private void Awake()
    {
        ship.Configure(GetInput(), GetCheckLimitsStrategy());
    }

    private ICheckLimits GetCheckLimitsStrategy()
    {
        if (useAI)
        {
            return new InitialPositionCheckLimits(ship.transform, 10f);
        }
        return new ViewportCheckLimits(ship.transform, Camera.main);
    }

    private IInput GetInput()
    {
        if (useAI)
        {
            return new AIInputAdapter(ship);
        }
        if (useJoystick)
        {
            return new JoystickInputAdapter(joystick);
        }
        Destroy(joystick.gameObject);
        return new UnityInputAdapter();
    }
}
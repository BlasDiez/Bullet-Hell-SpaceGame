using Ships;
using UnityEngine;

public class AIInputAdapter : IInput
{
    private readonly Ship _ship;
    private int _currentDirectionX;

    public AIInputAdapter(Ship ship)
    {
        _ship = ship;
        _currentDirectionX = 1;
    }

    public Vector2 GetDirection()
    {
        if (Camera.main != null)
        {
            var viewportPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);
            if (viewportPoint.x < 0.05f)
            {
                _currentDirectionX = 1;
                
            }
            else if (viewportPoint.x > 0.95f)
            {
                _currentDirectionX = -1;
            }
        }

        return new Vector2(_currentDirectionX, 0);
    }
}
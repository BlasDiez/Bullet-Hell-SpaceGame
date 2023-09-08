using UnityEngine;

namespace Ships
{
    public interface IInput
    {
         Vector2 GetDirection();
         bool IsFireActionPressed();
    }
}
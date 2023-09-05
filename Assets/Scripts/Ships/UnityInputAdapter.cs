using UnityEngine;

namespace Ships
{
    class UnityInputAdapter : IInput
    {
        public Vector2 GetDirection()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}
using System;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private IShip _ship;
        private ICheckLimits _checkLimits;
        private Transform _myTransform;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(IShip ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits;
        }
        
        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }
    }
}
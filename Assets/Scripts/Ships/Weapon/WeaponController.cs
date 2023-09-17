using System;
using System.Linq;
using UnityEngine;

namespace Ships.Weapon
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration projectilesConfiguration;
        [SerializeField] private ProjectileId defaultProjectileId;
        [SerializeField] private float firerateInSeconds;
        [SerializeField] private Transform projectileSpawnPosition;
        
        private ProjectileFactory _projectileFactory;
        private IShip _ship;
        
        private string _activeProjectileId;
        private float _remainingSecondsToBeAbleToShoot;

        private void Awake()
        {
            var instance = Instantiate(projectilesConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
        }

        public void Configure(IShip ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }
            Shoot();
        }
        
        private void Shoot()
        {
            var projectile = _projectileFactory
                .Create(_activeProjectileId, 
                    projectileSpawnPosition.position, 
                    projectileSpawnPosition.rotation);
            
            _remainingSecondsToBeAbleToShoot = firerateInSeconds;
        }
    }
    
    
}
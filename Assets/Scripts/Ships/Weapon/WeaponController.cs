using System.Linq;
using UnityEngine;

namespace Ships.Weapon
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float firerateInSeconds;
        [SerializeField] private Projectile[] projectilePrefabs;
        [SerializeField] private Transform projectileSpawnPosition;
        
        private IShip _ship;
        private string _activeProjectileId;
        private float _remainingSecondsToBeAbleToShoot;

        
        public void Configure(IShip ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _activeProjectileId = "Projectile1";
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
            var prefab = projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
            _remainingSecondsToBeAbleToShoot = firerateInSeconds;
            Instantiate(prefab, projectileSpawnPosition.position, projectileSpawnPosition.rotation);
        }
    }
    
    
}
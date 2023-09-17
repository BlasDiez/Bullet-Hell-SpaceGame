using UnityEngine;

namespace Ships.Weapon
{
    [CreateAssetMenu(menuName = "Create ProjectileId", fileName = "ProjectileId", order = 0)]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string value;
        public string Value => value;
    }
}
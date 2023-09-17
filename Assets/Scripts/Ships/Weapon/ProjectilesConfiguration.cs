using System;
using System.Collections.Generic;
using Ships.Weapon;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 0)]
public class ProjectilesConfiguration : ScriptableObject
{
    [SerializeField] private Projectile[] projectilesPrefabs;
    private Dictionary<string, Projectile> _idToProjectilePrefab;

    private void Awake()
    {
        _idToProjectilePrefab = new Dictionary<string, Projectile>();
        foreach (var projectile in projectilesPrefabs)
        {
            _idToProjectilePrefab.Add(projectile.Id, projectile);
        }
    }

    public Projectile GetProjectileById(string id)
    {
        if(!_idToProjectilePrefab.TryGetValue(id, out var projectile))
        {
            throw new Exception($"Projectile with id {id} not found");
        }
        return projectile;
    }
}
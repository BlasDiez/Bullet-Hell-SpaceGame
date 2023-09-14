using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ships.Weapon
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;
        
        public string Id => id;
        
        private void Start()
        {
            rigidbody2D.velocity = transform.up * speed;
            StartCoroutine(DestroyIn(3f));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
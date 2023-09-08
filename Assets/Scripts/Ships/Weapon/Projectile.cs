using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ships.Weapon
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;

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
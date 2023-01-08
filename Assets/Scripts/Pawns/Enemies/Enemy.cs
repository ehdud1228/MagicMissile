using System;
using UnityEngine;

namespace Pawn.Enemies
{
    public class Enemy : Pawns.Pawn
    {
        public float _health = 100f;
        
        private void Update()
        {
            var toPlayerDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
            Move(toPlayerDirection * moveSpeed);
        }
        
        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
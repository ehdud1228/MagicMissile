using System;
using UnityEngine;

namespace Pawn.Enemy
{
    public class EnemyAI : Pawns.Pawn
    {
        private void Update()
        {
            var toPlayerDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
            Move(toPlayerDirection * moveSpeed);
        }
    }
}
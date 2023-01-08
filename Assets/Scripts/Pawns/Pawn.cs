using System;
using UnityEngine;

namespace Pawns
{
    public class Pawn : MonoBehaviour
    {
        private Animator _animator;
        public Rigidbody2D Rigidbody2D { get; protected set; }
        
        public float moveSpeed;

        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        public void Move(Vector2 moveDir)
        {
            if(Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                if (moveDir.x < 0)
                {
                    _animator.SetInteger("Direction", 3);
                }
                else if (moveDir.x > 0)
                {
                    _animator.SetInteger("Direction", 2);
                }
            }
            else
            {
                if (moveDir.y > 0)
                {
                    _animator.SetInteger("Direction", 1);
                }
                else if (moveDir.y < 0)
                {
                    _animator.SetInteger("Direction", 0);
                }
            }
            _animator.SetBool("IsMoving", moveDir.magnitude > 0);
        
            GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        }
    }
}
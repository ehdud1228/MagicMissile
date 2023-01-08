using System;
using Impact;
using Pawn.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pawns.Player
{
    public class Bullet : MonoBehaviour
    {
        public float startMana = 10f;
        public GameObject hitEffect;
        
        public bool isMove = false;
        
        private float _leftMana = 10f;
        private BulletPool _bulletPool;

        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _bulletPool = FindObjectOfType<BulletPool>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _leftMana = startMana;
            
            // to Mouse Position with new Input System
            var mousePosition = Mouse.current.position.ReadValue();
            var mouseWorldPosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
            var direction = (mouseWorldPosition - (Vector2)PlayerController.Instance.transform.position).normalized;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(direction * 3f);
        }

        private void Update()
        {
            _leftMana -= Time.deltaTime * 2;
            
            if(_leftMana <= 0)
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.CompareTag($"Enemy"))
            {
                col.gameObject.GetComponent<Enemy>().TakeDamage(_leftMana);
                var hitEffect = Instantiate(this.hitEffect);
                hitEffect.GetComponent<HitEffect>().Hit((int)_leftMana);
                hitEffect.transform.position = col.transform.position;
                _rigidbody2D.velocity = Vector2.zero;
                _bulletPool.ReturnBullet(gameObject);
            }
        }
    }
}
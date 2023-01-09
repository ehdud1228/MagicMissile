using System;
using System.Collections.Generic;
using Impact;
using Pawn.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Pawns.Player
{
    public class Missile : MonoBehaviour
    {
        public float startMana = 10f;
        public GameObject hitEffect;
        public Rigidbody2D rb;
        
        public bool isMove = false;
        
        private float _leftMana = 10f;
        private MissilePool _missilePool;
        
        public List<IAddOn> StartAddOns = new List<IAddOn>(); 

        private void Awake()
        {
            _missilePool = FindObjectOfType<MissilePool>();
            rb = GetComponent<Rigidbody2D>();
            
            // tmp code
            var mousePosition = Mouse.current.position.ReadValue();
            var mouseWorldPosition = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
            var toMouseDirection = (mouseWorldPosition - (Vector2)PlayerController.Instance.transform.position).normalized;
            var addForceAddOn = new AddForceAddOn(AddForceAddOn.ForceType.FixedForce, 3);
            addForceAddOn.SetFixedForce(toMouseDirection);
            StartAddOns.Add(addForceAddOn);
        }

        private void OnEnable()
        {
            _leftMana = startMana;
            foreach (var startAddOn in StartAddOns)
            {
                _leftMana -= startAddOn.ControlMissile(this);
            }
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
                rb.velocity = Vector2.zero;
                _missilePool.ReturnBullet(gameObject);
            }
        }
    }
}
using System;
using UnityEngine;

namespace Pawns.Player
{
    public class MissileController : MonoBehaviour
    {
        private float _nowTime = 0;
        private BulletPool _bulletPool;

        private void Start()
        {
            _bulletPool = FindObjectOfType<BulletPool>();
        }

        private void Update()
        {
            if(_nowTime >= 1f)
            {
                var bl = _bulletPool.GetBullet();
                bl.SetActive(true);
                bl.transform.position = transform.position;
                _nowTime = 0;
            }

            _nowTime += Time.deltaTime;
        }
    }
}
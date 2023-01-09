using System;
using UnityEngine;

namespace Pawns.Player
{
    public class MissileSpawner : MonoBehaviour
    {
        private float _nowTime = 0;
        private MissilePool _missilePool;

        private void Start()
        {
            _missilePool = FindObjectOfType<MissilePool>();
        }

        private void Update()
        {
            if(_nowTime >= 1f)
            {
                var bl = _missilePool.GetBullet();
                bl.SetActive(true);
                bl.transform.position = transform.position;
                _nowTime = 0;
            }

            _nowTime += Time.deltaTime;
        }
    }
}
using UnityEngine;

namespace Pawns.Player
{
    public class BulletPool : MonoBehaviour
    {
        // bullet pool
        public GameObject bulletPrefab;
        public int poolSize = 20;
        private GameObject[] _bullets;
        private int _currentBullet = 0;
        
        // Start is called before the first frame update
        void Start()
        {
            _bullets = new GameObject[poolSize];
    
            for (int i = 0; i < poolSize; i++)
            {
                _bullets[i] = (GameObject)Instantiate(bulletPrefab, transform);
                _bullets[i].SetActive(false);
            }
        }
        
        public GameObject GetBullet()
        {
            if (!_bullets[_currentBullet].activeInHierarchy)
            {
                return _bullets[_currentBullet];
            }
            else
            {
                if (_currentBullet >= poolSize - 1)
                {
                    _currentBullet = 0;
                }
                else
                {
                    _currentBullet++;
                }
    
                return _bullets[_currentBullet];
            }
        }
        
        public void ReturnBullet(GameObject bullet)
        {
            bullet.SetActive(false);
        }
    }
}
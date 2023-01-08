using TMPro;
using UnityEngine;

namespace Impact
{
    public class HitEffect : MonoBehaviour
    {
        public void Hit(int damage)
        {
            var hitText = transform.Find("HitText").gameObject;
            hitText.GetComponent<TextMeshPro>().text = damage.ToString();
            
            // random float position
            var x = Random.Range(-0.3f, 0.3f);
            var y = Random.Range(-0.3f, 0.3f);
            hitText.transform.localPosition = new Vector3(x, y, 0);
        }
    }
}
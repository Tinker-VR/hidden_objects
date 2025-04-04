using UnityEngine;

namespace Tinker
{
    public class GhostAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _ghostObject;

        public void OnInteract()
        {
            _ghostObject.SetActive(false);
        }
    }
}

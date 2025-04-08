using UnityEngine;

namespace Tinker
{
    public class RotatingProps : RootInteractableObject
    {
        [SerializeField] private Vector3 m_offset;
        [SerializeField] private float m_rotateTime = 0.5f;
        
        [Header("Audio")]
        [SerializeField] private string m_sfxID;
        
        protected bool _isComplete;
        protected Vector3 _originalEulerAngles;

        public override void Start()
        {
            SetupOutline(GetComponentInChildren<MeshRenderer>());
            _originalEulerAngles = transform.eulerAngles;
        }

        public override void OnInteract()
        {
            base.OnInteract();
            var _targetEuler = _isComplete ? _originalEulerAngles : _originalEulerAngles + m_offset;

            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySFX(m_sfxID);
            }

            transform.LeanRotate(_targetEuler, m_rotateTime).setOnComplete(() => _isComplete = !_isComplete);
        }
    }
}

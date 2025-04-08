using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tinker
{
    public class MovingProps : RootInteractableObject
    {
        [SerializeField] private Vector3 m_offset;
        [SerializeField] private float m_moveTime;

        [Header("Audio")]
        [SerializeField] private string m_sfxID;
        
        protected bool _isComplete;
        protected Vector3 _originalPosition;
        public override void Start()
        {
            base.Start();
            _originalPosition = transform.position;
        }

        public override void OnInteract()
        {
            base.OnInteract();
            var _target = _isComplete ? _originalPosition : _originalPosition + m_offset;
            
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySFX(m_sfxID);
            }

            transform.LeanMove(_target, m_moveTime).setOnComplete(() => _isComplete = !_isComplete);
        }
    }
}

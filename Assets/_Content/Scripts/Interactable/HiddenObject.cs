using System;
using UnityEngine;

namespace Tinker
{
    public class HiddenObject : RootInteractableObject
    {
        [SerializeField] private string _id;
        [TextArea(2,3)]
        [SerializeField] private string _clueDescription;

        [Header("Visual Effects")]
        [SerializeField] private ParticleSystem _visualEffect;
        [SerializeField] private float _floatDistance = 0.2f;
        [SerializeField] private float _floatDuration = 1.5f;
        // Animator _animator;
        public string  Clue { get; set; }
        public bool HasFound { get; private set; }

        public override void Start()
        {
            base.Start();
            _isHidden = true;
        }

        public override void OnInteract()
        {
            if(HasFound)return;
            
            GameManager.OnHiddenObjectFound?.Invoke(_id);
            HasFound = true;
            
            OnHitFloatEffect();
        }

        private void OnHitFloatEffect()
        {
            var startPos = transform.position;
            if (_visualEffect != null)
            {
                Instantiate(_visualEffect, transform);
            }
            
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySFX("pick-up");
            }

            LeanTween.moveY(gameObject, startPos.y + _floatDistance, _floatDuration)
                .setEaseInOutSine().setOnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
        }

        public void ToggleObject(bool toggle)
        {
            if (!HasFound)
            {
                gameObject.SetActive(toggle);
            }
        }
        public void SetupId(string id)
        {
             _id = id;
        }
    }
}

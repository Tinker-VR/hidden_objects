using System;
using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

namespace Tinker
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private float m_interactDelay = 1f;
        private CinemachineImpulseSource   m_impulseSource;
        private IInteractable _interactable;
        private Camera _camera;
        private float _delayTimer;

        private void Start()
        {
            _camera = Camera.main;
            m_impulseSource = GetComponent<CinemachineImpulseSource>();
        }
        public void InteractWithObject(StarterAssetsInputs _input)
        {

            var _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out var _hit))
            {
                if (_hit.collider.TryGetComponent(out IInteractable _interact))
                {
                    if (_interactable != _interact)
                    {
                        _interactable?.OnHoverExit();
                    }

                    _interactable = _interact;
                    _interactable.OnHover();
                }
                else
                {
                    _interactable?.OnHoverExit();
                    _interactable = null;
                }
            }
            else
            {
                if (_interactable != null)
                {
                    _interactable?.OnHoverExit();
                    _interactable = null;
                }
            }
            OnInteract(_input);
        }

        private void OnInteract(StarterAssetsInputs _input)
        {
            _delayTimer += Time.fixedDeltaTime;

            if (!_input.interact) return;
            if (_delayTimer < m_interactDelay)
            {
                _input.interact = false;
                return;
            }

            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySFX("click");
            }


            if (_interactable == null)
            {
                ShakeCamera();
            }
            _interactable?.OnInteract();
            _delayTimer = 0;
            _input.interact = false;
        }

        private void ShakeCamera()
        {
            m_impulseSource?.GenerateImpulse();
        }

    }
}

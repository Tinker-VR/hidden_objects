using System;
using System.Collections;
using UnityEngine;

namespace Tinker
{
    public class Television : RootInteractableObject, IInteractable
    {
        [SerializeField] private GameObject _tvPanel;
        [SerializeField] private HiddenObject _hiddenObject;
        [SerializeField] private float _showHiddenObject = 2f;
        private bool _isOn = false;
        private float _timer;

        Coroutine _coroutine;
        private void Start()
        {
            _tvPanel.SetActive(false);
        }
        public void OnInteract()
        {
            _isOn = !_isOn;
            _tvPanel.SetActive(_isOn);
            if (_isOn)
            {
                _coroutine = StartCoroutine(ShowHiddenObjectRoutine());
            }
            else
            {
                StopCoroutine(_coroutine);
                _timer = 0;
                _hiddenObject.ToggleObject(false);
            }
        }

        IEnumerator ShowHiddenObjectRoutine()
        {
            while (_timer < _showHiddenObject)
            {
                _timer += Time.deltaTime;
                yield return null;
            }
            _hiddenObject.ToggleObject(true);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tinker
{
    public class HiddenObjectManager : MonoBehaviour
    {
        [SerializeField] private Transform _hiddenObjectParent;
        [SerializeField] private List<HiddenObject>  hiddenObjects = new List<HiddenObject>();

        public int HiddenObjectsCount => hiddenObjects.Count;
        public bool CheckAllFound => hiddenObjects.All(x => x.HasFound);
        
        
        private HiddenObject _currentHiddenObject;
        private string  _currentClueDescription;
        
        public void GetAssistance()
        {
            if (CheckAllFound)
            {
                Debug.Log("All object has found");
                return;
            }

            if (_currentHiddenObject != null)
            {
                if (!_currentHiddenObject.HasFound)
                {
                    Debug.Log(_currentClueDescription);
                    return;
                }
            }
            
            //Get Clue from AI
            _currentHiddenObject = hiddenObjects.FirstOrDefault(x => !x.HasFound);
            if (_currentHiddenObject != null)
            {
                _currentClueDescription = _currentHiddenObject.Clue;
            }

        }

        private void OnValidate()
        {
            if(_hiddenObjectParent == null)return;
            foreach (Transform child in _hiddenObjectParent)
            {
                if (child.TryGetComponent(out HiddenObject hiddenObject))
                {
                    if (!hiddenObjects.Contains(hiddenObject))
                    {
                        hiddenObjects.Add(hiddenObject);
                    }
                }
            }
        }
    }
}

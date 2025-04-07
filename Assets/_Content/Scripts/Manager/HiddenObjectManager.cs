using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tinker
{
    public class HiddenObjectManager : MonoBehaviour
    {
        [SerializeField] private List<HiddenObject>  hiddenObjects = new List<HiddenObject>();

        public int HiddenObjectsCount => hiddenObjects.Count;
        public bool CheckAllFound => hiddenObjects.All(x => x.HasFound);
        
        
        private HiddenObject _currentHiddenObject;
        private string  _currentClueDescription;

        private void Awake()
        {
            GetAllHiddenObjects();
        }

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
        
        [ContextMenu("Get All Hidden Objects")]
        public void GetAllHiddenObjects()
        {
            hiddenObjects.Clear();
            var allHiddenObjects = FindObjectsByType<HiddenObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            for (var i = 0; i < allHiddenObjects.Length; i++)
            {
                hiddenObjects.Add(allHiddenObjects[i]);
                allHiddenObjects[i].SetupId($"socks_{i + 1}");
            }
        }
    }
}

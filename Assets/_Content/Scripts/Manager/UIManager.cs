using System;
using TMPro;
using UnityEngine;

namespace Tinker
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreTMP;
        private void OnEnable()
        {
            GameManager.OnUpdateInGameData += OnUpdateInGameData;
        }
        private void OnDisable()
        {
            GameManager.OnUpdateInGameData += OnUpdateInGameData;
        }
        
        private void OnUpdateInGameData(InGameData ingamedata)
        {
            m_scoreTMP.text = $"{ingamedata.ObjectFoundCount:00}/{ingamedata.totalHiddenObjects:00}";
        }

    }
}

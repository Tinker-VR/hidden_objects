using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tinker
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreTMP;
        [SerializeField] private GameObject m_endGamePanel;
        private void OnEnable()
        {
            GameManager.OnUpdateInGameData += OnUpdateInGameData;
            GameManager.OnEndGame += OnEndGame;
        }


        private void OnDisable()
        {
            GameManager.OnUpdateInGameData -= OnUpdateInGameData;
            GameManager.OnEndGame -= OnEndGame;
        }
        
        private void OnUpdateInGameData(InGameData ingamedata)
        {
            m_scoreTMP.text = $"{ingamedata.ObjectFoundCount:00}/{ingamedata.totalHiddenObjects:00}";
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void OnEndGame()
        {
            m_endGamePanel.SetActive(true);
        }
    }
}

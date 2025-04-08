using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tinker
{
    public class GameManager : MonoBehaviour
    {
        public delegate void HiddenObjectFoundEvent(string id);
        public delegate void UpdateGameDataEvent(InGameData inGameData);
        public delegate void PauseGameEvent(bool paused);
        public delegate void EndGameEvent();
        
        
        public static HiddenObjectFoundEvent OnHiddenObjectFound;
        public static UpdateGameDataEvent OnUpdateInGameData;
        public static PauseGameEvent OnPauseGame;
        public static EndGameEvent OnEndGame;
        
       private HiddenObjectManager m_hiddenObjectManager; 

       private InGameData _inGameData;

       private void OnEnable()
       {
           OnHiddenObjectFound += HiddenObjectFound;
           OnPauseGame += PauseGame;
       }


       private void OnDisable()
       {
           OnHiddenObjectFound -= HiddenObjectFound;
           OnPauseGame -= PauseGame;
       }

       private void Start()
        {
            m_hiddenObjectManager = GetComponent<HiddenObjectManager>();
            _inGameData = new InGameData
            {
                levelId = SceneManager.GetActiveScene().name,
                totalHiddenObjects = m_hiddenObjectManager.HiddenObjectsCount
            };
            OnUpdateInGameData?.Invoke(_inGameData);
        }
       
        private void HiddenObjectFound(string id)
        {
            if(_inGameData == null) return;
            _inGameData.AddFoundHiddenObject(id);
            OnUpdateInGameData?.Invoke(_inGameData);
            if (_inGameData.IsLevelComplete)
            {
                Debug.Log("Level Complete");
                OnEndGame?.Invoke();
            }
        }
        
        private void PauseGame(bool paused)
        {
           Time.timeScale = paused ? 0 : 1;
        }

    }
}

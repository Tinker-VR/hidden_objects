using UnityEngine;

namespace Tinker
{
    public class GameManager : MonoBehaviour
    {
        public delegate void HiddenObjectFound(string id);
        public static HiddenObjectFound OnHiddenObjectFound;
        void Start()
        {
        
        }
        void Update()
        {
        
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Tinker
{
    public class ButtonAutoSetup : MonoBehaviour
    {
        void Start()
        {
            var _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            AudioManager.Instance.PlaySFX("click");
        }
    }
}

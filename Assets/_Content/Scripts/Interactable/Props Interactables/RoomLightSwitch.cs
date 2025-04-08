using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Tinker
{
    public class RoomLightSwitch : RootInteractableObject
    {
        [SerializeField] private Light[] m_lights;
        [SerializeField] private bool _isOn;
        [SerializeField] private UnityEvent<bool> m_lightsOnEvent;
        [SerializeField] private UnityEvent<bool> m_lightsOffEvent;
        public override void Start()
        {
            base.Start();
            ToggleLights();
        }

        public override void OnInteract()
        {
            base.OnInteract();
            _isOn = !_isOn;
            ToggleLights();
        }

        private void ToggleLights()
        {
            foreach (var light in m_lights)
            {
                light.enabled = _isOn;
            }
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySFX("light-switch");
            }
            m_lightsOnEvent?.Invoke(_isOn);
            m_lightsOffEvent?.Invoke(!_isOn);
        }
    }
}

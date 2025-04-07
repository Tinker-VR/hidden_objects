using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

namespace Tinker
{
    public class StandingLamp : RootInteractableObject
    {
        [SerializeField] Light m_light;
        [SerializeField] private UnityEvent<bool> m_onInteract;
        public override void OnInteract()
        {
            m_light.enabled = !m_light.enabled;
            
            m_onInteract.Invoke(m_light.enabled);
        }
    }
}

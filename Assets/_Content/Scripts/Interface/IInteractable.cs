using UnityEngine;

namespace Tinker
{
    public interface IInteractable
    {
        public void OnHover();
        
        public void OnInteract();
        public void OnHoverExit();

    }
}

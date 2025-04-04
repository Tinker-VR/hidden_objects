using UnityEngine;

namespace Tinker
{
    public class RootInteractableObject : MonoBehaviour, IInteractable
    {
        protected bool _isHidden = false;
        private bool isHovered;
        public virtual void OnHover()
        {
            if(_isHidden)return;
            if(isHovered)return;
            isHovered = true;
        }

        public virtual  void OnHoverExit()
        {

        }

        public virtual  void OnInteract()
        {
            if(_isHidden)return;
            if (isHovered)
            {
                isHovered = false;
            }
        }
    }
}

using System.Linq;
using UnityEngine;

namespace Tinker
{
    public class RootInteractableObject : MonoBehaviour, IInteractable
    {
        protected bool _isHidden = false;
        private bool isHovered;

        [SerializeField] private Material m_outlineMaterial;
        private MeshRenderer _meshRenderer;
        private Material[] _originalMaterials;
        private Material[] _outlineMaterials;

        public virtual void Start()
        {
            if (TryGetComponent(out MeshRenderer renderer))
            {
                _meshRenderer = renderer;
                _originalMaterials = renderer.materials;

                if (m_outlineMaterial != null)
                {
                    _outlineMaterials = new Material[_originalMaterials.Length + 1];
                    _originalMaterials.CopyTo(_outlineMaterials, 0);
                    _outlineMaterials[_outlineMaterials.Length - 1] = m_outlineMaterial;
                }
            }
        }

        public virtual void OnHover()
        {
            if (_isHidden || isHovered || m_outlineMaterial == null) return;

            _meshRenderer.materials = _outlineMaterials;
            isHovered = true;
        }

        public virtual void OnHoverExit()
        {
            if (!isHovered || m_outlineMaterial == null) return;

            _meshRenderer.materials = _originalMaterials;
            isHovered = false;
        }

        public virtual void OnInteract()
        {
            if (_isHidden) return;

            if (isHovered)
            {
                OnHoverExit(); 
            }
        }
    }
}
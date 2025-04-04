using System;
using UnityEngine;

namespace Tinker
{
    public class HiddenObject : RootInteractableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private bool _visible = true;
        [TextArea(2,3)]
        [SerializeField] private string _clueDescription;

        Animator _animator;
        public string  Clue { get; set; }
        public bool HasFound { get; private set; }

        private void Start()
        {
            _isHidden = true;
            _animator = GetComponentInChildren<Animator>();
            if (!_visible)
            {
                gameObject.SetActive(false);
            }
        }

        public override void OnInteract()
        {
            if(HasFound)return;
            HasFound = true;
            _animator.Play("hit");
        }
        
        public void ToggleObject(bool toggle)
        {
            if (!HasFound)
            {
                gameObject.SetActive(toggle);
            }
        }

        private void OnValidate()
        {
            if (transform.parent != null)
            {
                Transform parent = transform.parent;
                for (int i = 0; i < parent.childCount; i++)
                {
                    if (parent.GetChild(i) == transform)
                    {
                        _id = $"ghost_{i+1:00}";
                        break;
                    }
                }
            }
        }

    }
}

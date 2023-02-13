using UnityEngine;
using System.Collections.Generic;

namespace Lab5Games.UIKit
{
    public class ButtonGroup : MonoBehaviour
    {
        [SerializeField] private bool multipleSelection = false;
        [SerializeField] private GroupableButton[] buttons;

        private List<GroupableButton> m_SelectedButtons = new List<GroupableButton>();
        protected List<GroupableButton> m_CacheButtons = new List<GroupableButton>();

        public void RegisterButton(GroupableButton button)
        {
            button.m_Group = this;
        }

        public virtual void ResetButtons()
        {
            foreach(var btn in m_CacheButtons)
            {
                if(IsSelected(btn))
                {
                    continue;
                }
                else
                {
                    btn.OnReset();
                }
            }
        }

        bool IsSelected(GroupableButton button)
        {
            return m_SelectedButtons.Contains(button);
        }

        public void UnselectAll()
        {
            m_SelectedButtons.Clear();
        }

        public void Select(GroupableButton button)
        {
            if (multipleSelection)
            {
                m_SelectedButtons.Add(button);
            }
            else
            {
                if(m_SelectedButtons.Count == 0)
                {
                    m_SelectedButtons.Add(button);
                }    
                else
                {
                    m_SelectedButtons[0] = button;
                }
            }
        }

        public virtual void OnEnterButton(GroupableButton button)
        {
            if (!isActiveAndEnabled)
                return;

            ResetButtons();

            if(!IsSelected(button))
            {
                button.OnEnter();
            }
        }
        
        public virtual void OnExitButton(GroupableButton button)
        {
            if (!isActiveAndEnabled)
                return;

            ResetButtons();
        }

        public virtual void OnSelectButton(GroupableButton button)
        {
            if (!isActiveAndEnabled)
                return;

            if(IsSelected(button))
            {
                if(multipleSelection)
                {
                    m_SelectedButtons.Remove(button);
                }
                else
                {
                    return;
                }
            }
            else
            {
                Select(button);
            }

            ResetButtons();
        }

        private void OnEnable()
        {
            ResetButtons();
        }

        private void OnDisable()
        {
            UnselectAll();
        }

        private void Awake()
        {
            foreach(var btn in buttons)
            {
                RegisterButton(btn);
            }
        }
    }
}

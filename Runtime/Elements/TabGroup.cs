using System.Collections.Generic;
using UnityEngine;

namespace Lab5Games.UIKit
{
    // https://www.youtube.com/watch?v=211t6r12XPQ&list=RDCMUCR35rzd4LLomtQout93gi0w&index=16

    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private TabButton[] m_CacheButtons;

        private TabButton m_SelectedButton = null;
        protected List<TabButton> m_Buttons = null;

        public virtual void OnEnterButton(TabButton button)
        {
            if (!enabled)
                return;

            ResetTabs();

            if(m_SelectedButton == null || m_SelectedButton != button)
            {
                button.EnterButton();
            }
        }

        public virtual void OnExitButton(TabButton button)
        {
            if (!enabled)
                return;

            ResetTabs();
        }

        public virtual void OnSelectButton(TabButton button)
        {
            if (!enabled)
                return;

            if(m_SelectedButton != null)
            {
                if (m_SelectedButton == button)
                    return;
            }

            m_SelectedButton = button;
            m_SelectedButton.SelectButton();

            ResetTabs();
        }

        public virtual void ResetTabs()
        {
            foreach (var btn in m_Buttons)
            {
                if (m_SelectedButton != null && m_SelectedButton == btn)
                    continue;

                btn.ResetButton();
            }
        }

        private void Awake()
        {
            m_Buttons = new List<TabButton>();

            foreach(var btn in m_CacheButtons)
            {
                btn.onPointerClick += OnSelectButton;
                btn.onPointerEnter += OnEnterButton;
                btn.onPointerExit += OnExitButton;

                m_Buttons.Add(btn);
            }
        }

        protected virtual void OnEnable()
        {
            ResetTabs();
        }
    }
}

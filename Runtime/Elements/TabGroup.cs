using System.Collections.Generic;
using UnityEngine;

namespace Lab5Games.UI
{
    // https://www.youtube.com/watch?v=211t6r12XPQ&list=RDCMUCR35rzd4LLomtQout93gi0w&index=16

    public class TabGroup : MonoBehaviour
    {
        [SerializeField] TabButton[] m_CacheButtons;

        TabButton m_SelectedButton = null;
        List<TabButton> m_Buttons = null;

        public void OnTabEnter(TabButton button)
        {
            if (!enabled)
                return;

            ResetTabs();

            if(m_SelectedButton == null || m_SelectedButton != button)
            {
                button.EnterButton();
            }
        }

        public void OnTabExit(TabButton button)
        {
            if (!enabled)
                return;

            ResetTabs();
        }

        public void OnTabSelected(TabButton button)
        {
            if (!enabled)
                return;

            if(m_SelectedButton != null)
            {
                if (m_SelectedButton == button)
                    return;

                m_SelectedButton.DeselectButton();
            }

            m_SelectedButton = button;
            m_SelectedButton.SelectButton();

            ResetTabs();
        }

        public void ResetTabs()
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
                btn.onPointerClick += OnTabSelected;
                btn.onPointerEnter += OnTabEnter;
                btn.onPointerExit += OnTabExit;

                m_Buttons.Add(btn);
            }
        }

        private void OnEnable()
        {
            ResetTabs();
        }
    }
}

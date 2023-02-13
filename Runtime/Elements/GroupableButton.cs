using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Lab5Games.UIKit
{
    public class GroupableButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        internal ButtonGroup m_Group;

        [SerializeField] protected UnityEvent onReset;
        [SerializeField] protected UnityEvent onEnter;
        [SerializeField] protected UnityEvent onSelect;

        public virtual void OnReset()
        {
            onReset?.Invoke();
        }

        public virtual void OnEnter()
        {
            onEnter?.Invoke();
        }

        public virtual void OnSelect()
        {
            onSelect?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_Group.OnExitButton(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_Group.OnEnterButton(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_Group.OnSelectButton(this);
        }
    }
}

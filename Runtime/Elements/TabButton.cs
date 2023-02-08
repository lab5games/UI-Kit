using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Lab5Games.UI
{
    public delegate void TabButtonDelegate(TabButton tabButton); 

    public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] UnityEvent onReset;
        [SerializeField] UnityEvent onEnter;
        [SerializeField] UnityEvent onSelect;
        [SerializeField] UnityEvent onDeselect;

        public event TabButtonDelegate onPointerClick;
        public event TabButtonDelegate onPointerEnter;
        public event TabButtonDelegate onPointerExit;

        public virtual void ResetButton()
        {
            onReset?.Invoke();
        }

        public virtual void EnterButton()
        {
            onEnter?.Invoke();
        }

        public virtual void SelectButton()
        {
            onSelect?.Invoke();
        }

        public virtual void DeselectButton()
        {
            onDeselect?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onPointerExit?.Invoke(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnter?.Invoke(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            onPointerClick?.Invoke(this);
        }
    }
}

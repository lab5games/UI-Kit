using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lab5Games.UIKit
{
    //https://qiita.com/rarudonet/items/52de2fd3a47b6e0a2b1f

    [ExecuteAlways, DisallowMultipleComponent]
    [RequireComponent(typeof(Graphic))]
    public abstract class UIEffectControlBase : UIBehaviour, IMaterialModifier
    {
        protected Material m_CopyMaterial = null;

        protected Graphic m_Graphic;
        public Graphic graphic
        {
            get
            {
                if (m_Graphic == null)
                    m_Graphic = GetComponent<Graphic>();

                return m_Graphic;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            graphic.SetMaterialDirty();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            if (m_CopyMaterial != null)
                DestroyImmediate(m_CopyMaterial);

            m_CopyMaterial = null;
            graphic.SetMaterialDirty();
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            if (!IsActive() || graphic == null) return;
            graphic.SetMaterialDirty();
        }
#endif

        protected override void OnDidApplyAnimationProperties()
        {
            base.OnDidApplyAnimationProperties();

            if (!IsActive() || graphic == null) return;
            graphic.SetMaterialDirty();
        }

        public Material GetModifiedMaterial(Material baseMaterial)
        {
            if(IsActive() == false || m_Graphic == null || !CheckProperties(baseMaterial))
            {
                return baseMaterial;
            }

            if(m_CopyMaterial == null)
            {
                m_CopyMaterial = new Material(baseMaterial);
                m_CopyMaterial.hideFlags = HideFlags.HideAndDontSave;
            }

            m_CopyMaterial.CopyPropertiesFromMaterial(baseMaterial);
            SetProperties(m_CopyMaterial);

            return m_CopyMaterial;
        }

        protected abstract bool CheckProperties(Material baseMaterial);
        protected abstract void SetProperties(Material copyMaterial);
    }
}

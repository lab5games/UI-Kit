﻿using UnityEngine;

namespace Lab5Games.UI
{
    [AddComponentMenu("UI/Effects/UIPixelization")]
    public class UIPixelization : UIEffectControlBase
    {
        [SerializeField, Range(0f, 1f)]
        private float m_Factor = 0.5f;
        public float factor
        {
            get => m_Factor;
            set => m_Factor = value;
        }

        public readonly int FactorPropertyID = Shader.PropertyToID("_Factor");

        protected override bool CheckProperties(Material baseMaterial)
        {
            return baseMaterial.HasProperty(FactorPropertyID);
        }

        protected override void SetProperties(Material copyMaterial)
        {
            copyMaterial.SetFloat(FactorPropertyID, factor);
        }
    }
}

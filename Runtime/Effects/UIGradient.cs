using UnityEngine;

namespace Lab5Games.UIKit
{
    [AddComponentMenu("UI/Effects/UIGradient")]
    public class UIGradient : UIEffectControlBase
    {
        [SerializeField, Range(0f, 1f)]
        private float m_Blend = 0.5f;
        public float blend
        {
            get => m_Blend;
            set => m_Blend = value;
        }

        [SerializeField, Range(0f, 10f)]
        private float m_BoostY = 1.0f;
        public float boostY
        {
            get => m_BoostY;
            set => m_BoostY = value;    
        }

        [SerializeField]
        private Color m_BottomColor = Color.black;
        public Color bottomColor
        {
            get => m_BottomColor;
            set => m_BottomColor = value;
        }

        [SerializeField]
        private Color m_TopColor = Color.white;
        public Color topColor
        {
            get => m_TopColor;
            set => m_TopColor = value;
        }


        public readonly int BlendPropertyID = Shader.PropertyToID("_GradBlend");
        public readonly int BoostYPropertyID = Shader.PropertyToID("_GradBoostY");
        public readonly int BotColorPropertyID = Shader.PropertyToID("_GradBotColor");
        public readonly int TopColorPropertyID = Shader.PropertyToID("_GradTopColor");

        protected override bool CheckProperties(Material baseMaterial)
        {
            return baseMaterial.HasProperty(BlendPropertyID) && baseMaterial.HasProperty(BoostYPropertyID) &&
                baseMaterial.HasProperty(BotColorPropertyID) && baseMaterial.HasProperty(TopColorPropertyID);
        }

        protected override void SetProperties(Material copyMaterial)
        {
            copyMaterial.SetFloat(BlendPropertyID, blend);
            copyMaterial.SetFloat(BoostYPropertyID, boostY);
            copyMaterial.SetColor(BotColorPropertyID, bottomColor);
            copyMaterial.SetColor(TopColorPropertyID, topColor);
        }
    }
}

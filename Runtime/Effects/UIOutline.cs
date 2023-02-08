using UnityEngine;

namespace Lab5Games.UI
{
    [AddComponentMenu("UI/Effects/UIOutline")]
    public class UIOutline : UIEffectControlBase
    {
        [SerializeField, Range(0f, 0.1f)]
        private float m_LineWidth = 0.01f;
        public float lineWidth
        {
            get => m_LineWidth;
            set => m_LineWidth = value;
        }

        [SerializeField]
        private Color m_LineColor = Color.white;
        public Color lineColor
        {
            get => m_LineColor;
            set => m_LineColor = value;
        }

        [SerializeField, Range(0f, 1f)]
        private float m_LineAlpha = 1.0f;
        public float lineAlpha
        {
            get => m_LineAlpha;
            set => m_LineAlpha = value;
        }

        public readonly int WidthPropertyID = Shader.PropertyToID("_LineWidth");
        public readonly int ColorPropertyID = Shader.PropertyToID("_LineColor");
        public readonly int AlphaPropertyID = Shader.PropertyToID("_LineAlpha");

        protected override bool CheckProperties(Material baseMaterial)
        {
            return baseMaterial.HasProperty(WidthPropertyID) && baseMaterial.HasProperty(ColorPropertyID) &&
                baseMaterial.HasProperty(AlphaPropertyID);
        }

        protected override void SetProperties(Material copyMaterial)
        {
            copyMaterial.SetFloat(WidthPropertyID, lineWidth);
            copyMaterial.SetColor(ColorPropertyID, lineColor);
            copyMaterial.SetFloat(AlphaPropertyID, lineAlpha);
        }
    }
}

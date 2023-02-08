using UnityEngine;

namespace Lab5Games.UI
{
    [AddComponentMenu("UI/Effects/UIInline")]
    public class UIInline : UIEffectControlBase
    {
        [SerializeField]
        private float m_LineWidth = 0.5f;
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

        public readonly int WidthPropertyID = Shader.PropertyToID("_LineWidth");
        public readonly int ColorPropertyID = Shader.PropertyToID("_LineColor");

        protected override bool CheckProperties(Material baseMaterial)
        {
            return baseMaterial.HasProperty(WidthPropertyID) && baseMaterial.HasProperty(ColorPropertyID);
        }

        protected override void SetProperties(Material copyMaterial)
        {
            copyMaterial.SetFloat(WidthPropertyID, lineWidth);
            copyMaterial.SetColor(ColorPropertyID, lineColor); 
        }
    }
}

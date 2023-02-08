using UnityEngine;

namespace Lab5Games.UI
{
    [AddComponentMenu("UI/Effects/UIBlur")]
    public class UIBlur : UIEffectControlBase
    {
        [SerializeField, Range(0f, 10f)] 
        private float m_Blur = 2.5f;
        public float blur
        {
            get => m_Blur;
            set => m_Blur = value;  
        }

        public readonly int BlurPropertyId = Shader.PropertyToID("_Blur");

        protected override bool CheckProperties(Material baseMaterial)
        {
            return baseMaterial.HasProperty(BlurPropertyId);
        }

        protected override void SetProperties(Material copyMaterial)
        {
            copyMaterial.SetFloat(BlurPropertyId, blur);
        }
    }
}

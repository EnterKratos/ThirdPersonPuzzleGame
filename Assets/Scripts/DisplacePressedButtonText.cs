using UnityEngine;

namespace EnterKratos
{
    public class DisplacePressedButtonText : MonoBehaviour
    {
        [SerializeField]
        private RectTransform textRect;

        [SerializeField]
        private int offsetX;

        [SerializeField]
        private int offsetY;

        private Vector3 originalPosition;

        public void Down()
        {
            textRect.localPosition = new Vector3(
                originalPosition.x + offsetX,
                originalPosition.y - offsetY,
                originalPosition.z
            );
        }

        public void Up()
        {
            textRect.localPosition = originalPosition;
        }

        private void Awake()
        {
            originalPosition = textRect.localPosition;
        }
    }
}
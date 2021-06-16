using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

namespace JaeHeum
{
    [ExcludeFromCodeCoverage]
    public class TetrisImage : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void UpdateTetrisImageBlock()
        {
            _image.color = Color.red;
        }

        public void UpdateTetrisImageBlank()
        {
            _image.color = Color.white;
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace JaeHeum
{
    [ExcludeFromCodeCoverage]
    public class TetrisView : MonoBehaviour
    {
        [SerializeField] private TetrisViewVertical _tetrisViewVertical = null;
        
        public void UpdateTetrisView(int[,] tetrisData)
        {
            _tetrisViewVertical.UpdateTetrisVerticalView(tetrisData);
        }

        public void ResetTetris()
        {
            _tetrisViewVertical.ResetTetris();
        }
    }
}
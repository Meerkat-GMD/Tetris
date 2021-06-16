using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace JaeHeum
{
    [ExcludeFromCodeCoverage]
    public class TetrisViewHorizon : MonoBehaviour
    {
        [SerializeField] private List<TetrisImage> _tetrisImageList = new List<TetrisImage>();

        public void UpdateTetrisHorizonView(int[] tetrisData)
        {
            for (int i = 0; i < _tetrisImageList.Count; i++)
            {
                if (tetrisData[i] != 0)
                {
                    _tetrisImageList[i].UpdateTetrisImageBlock();
                }
                else
                {
                    _tetrisImageList[i].UpdateTetrisImageBlank();
                }
            }
        }

        public void ResetTetris()
        {
            foreach (var unit in _tetrisImageList)
            {
                unit.UpdateTetrisImageBlank();
            }
        }
    }
}
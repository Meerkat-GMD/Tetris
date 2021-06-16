using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace JaeHeum
{
    [ExcludeFromCodeCoverage]
    public class TetrisViewVertical : MonoBehaviour
    {
        [SerializeField] private List<TetrisViewHorizon> _tetrisViewHorizons = new List<TetrisViewHorizon>();

        public void UpdateTetrisVerticalView(int[,] tetrisData)
        {
            for (int i = 2; i < tetrisData.GetLength(0); i++)
            {
                _tetrisViewHorizons[i - 2].UpdateTetrisHorizonView(GetRow(tetrisData, i));
            }
        }

        public void ResetTetris()
        {
            foreach (var unit in _tetrisViewHorizons)
            {
                unit.ResetTetris();
            }
        }

        private int[] GetRow(int[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
        }
    }
}
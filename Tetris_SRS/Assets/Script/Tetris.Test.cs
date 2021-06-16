using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JaeHeum
{
    public partial class Tetris
    {
        public GameState<Tetris> GetGameState()
        {
            return _gameState;
        }

        public bool IsTetrisDataEmpty()
        {
            var isEmpty = true;
            for (int i = 0; i < _blockPanelData.GetLength(0); i++)
            {
                for (int j = 0; j < _blockPanelData.GetLength(1); j++)
                {
                    if (_blockPanelData[i, j] != 0)
                    {
                        isEmpty = false;
                    }
                }
            }

            return isEmpty;
        }

        public int[,] GetBlockPanelData()
        {
            return _blockPanelData;
        }

        public int[,] GetBlockStackOnlyData()
        {
            return _blockStackOnlyData;
        }

        public IBlock GetCurrentBlock()
        {
            return _currentBlock;
        }
    }
}


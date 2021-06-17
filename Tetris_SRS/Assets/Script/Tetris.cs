using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace JaeHeum
{
    public partial class Tetris
    {
        public enum Direction
        {
            Left,
            Right,
        }

        public const int PanelSettingHeight = 2;
        public const int PanelHeight = 22;
        public const int PanelWidth = 10;
        private GameState<Tetris> _gameState;
        private IBlock _currentBlock;
        private List<IBlock> _blockList = new List<IBlock>();
        private int[,] _blockPanelData = new int[PanelHeight, PanelWidth];
        private int[,] _blockStackOnlyData = new int[PanelHeight, PanelWidth];
        private const float TimeToDown = 1.0f;
        private float timer = 0.0f;

        private const int BlockStartY = 0;
        private const int BlockStartX = 3;
        private Vector2Int _currentBlockPosition;

        private Action<int[,]> _updateTetrisView;

        public void Init(Action<int[,]> updateTetrisView)
        {
            _updateTetrisView = updateTetrisView;
            _blockList.Add(new BlockI());
            _blockList.Add(new BlockJ());
            _blockList.Add(new BlockL());
            _blockList.Add(new BlockO());
            _blockList.Add(new BlockS());
            _blockList.Add(new BlockT());
            _blockList.Add(new BlockZ());
            ChangeState<Tetris>(new InitGame());
        }

        public void Execute()
        {
            _gameState.Execute(this);
        }


        public void ChangeState<T>(GameState<Tetris> nextGameState)
        {
            _gameState?.Exit(this);

            _gameState = nextGameState;

            _gameState?.Enter(this);
        }

        public void Reset()
        {
            Clear();
            ResetBlockPosition();
            UpdateTetrisView();
        }

        public void Clear()
        {
            for (int i = 0; i < PanelHeight; i++)
            {
                for (int j = 0; j < PanelWidth; j++)
                {
                    _blockPanelData[i, j] = 0;
                    _blockStackOnlyData[i, j] = 0;
                }
            }
        }

        public void SelectBlock()
        {
            var random = new Random();
            var number = random.Next(0, _blockList.Count);

            SetCurrentBlock(number);
        }

        public void CreateBlock()
        {
            _currentBlock?.Create();
        }

        public void ResetBlockPosition()
        {
            _currentBlockPosition = new Vector2Int(BlockStartX, BlockStartY);
        }

        //currentPosition을 원래대로 돌릴 필요가 있나?
        public void SetBlockData(out bool success)
        {
            var copyPanel = _blockStackOnlyData.Clone() as int[,];
            var shape = _currentBlock.GetBlockShape();
            var blockWidth = _currentBlock.GetWidth();
            var blockHeight = _currentBlock.GetHeight();
            var xPos = _currentBlockPosition.x;
            var yPos = _currentBlockPosition.y;

            for (int i = 0; i < blockHeight; i++)
            {
                for (int j = 0; j < blockWidth; j++)
                {
                    if (shape[i, j] != 1)
                    {
                        continue;
                    }

                    if (i + yPos >= PanelHeight || j + xPos >= PanelWidth || i + yPos < 0 || j + xPos < 0)
                    {
                        success = false;
                        return;
                    }

                    if (copyPanel[i + yPos, j + xPos] == 1)
                    {
                        success = false;
                        return;
                    }

                    copyPanel[i + yPos, j + xPos] = shape[i, j];
                }
            }

            _blockPanelData = copyPanel.Clone() as int[,];
            success = true;
        }

        public bool RotateBlock()
        {
            _currentBlock.Rotation();
            SetBlockData(out var isSet);
            if (!isSet)
            {
                _currentBlock.ReverseRotation();
            }

            return isSet;
        }

        public void MoveBlockHorizon(Direction direction)
        {
            var move = false;
            switch (direction)
            {
                case Direction.Left:
                {
                    var blockShape = _currentBlock.GetBlockShape();
                    for (int i = 0; i < blockShape.GetLength(0); i++)
                    {
                        if (blockShape[i, 0] != 0)
                        {
                            if (_currentBlockPosition.x - 1 < 0)
                            {
                                return;
                            }
                        }
                    }

                    _currentBlockPosition = new Vector2Int(_currentBlockPosition.x - 1, _currentBlockPosition.y);
                    move = true;
                    break;
                }

                case Direction.Right:
                {
                    var blockShape = _currentBlock.GetBlockShape();
                    for (int i = 0; i < blockShape.GetLength(0); i++)
                    {
                        if (blockShape[i, blockShape.GetLength(1) - 1] != 0)
                        {
                            if (_currentBlockPosition.x + blockShape.GetLength(1) + 1 > PanelWidth)
                            {
                                return;
                            }
                        }
                    }

                    _currentBlockPosition = new Vector2Int(_currentBlockPosition.x + 1, _currentBlockPosition.y);
                    move = true;
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            SetBlockData(out var success);

            if (!success && move)
            {
                switch (direction)
                {
                    case Direction.Left:
                        _currentBlockPosition = new Vector2Int(_currentBlockPosition.x + 1, _currentBlockPosition.y);
                        break;
                    case Direction.Right:
                        _currentBlockPosition = new Vector2Int(_currentBlockPosition.x - 1, _currentBlockPosition.y);
                        break;
                }
            }
        }

        public void MoveBlockDown(out bool success)
        {
            _currentBlockPosition = new Vector2Int(_currentBlockPosition.x, _currentBlockPosition.y + 1);
            SetBlockData(out var isSet);
            success = isSet;
        }

        public bool IsTimeToDown()
        {
            timer += Time.deltaTime; //이 함수가 update에서 도는게 아니라면 수정해야됨
            if (timer > TimeToDown)
            {
                ResetTimer();
                return true;
            }

            return false;
        }

        public void ResetTimer()
        {
            timer = 0.0f;
        }
        
        public void BoomTetris()
        {
            for (int i = 0; i < _blockPanelData.GetLength(0); i++)
            {
                var boom = true;
                for (int j = 0; j < _blockPanelData.GetLength(1); j++)
                {
                    if (_blockPanelData[i, j] == 0)
                    {
                        boom = false;
                        break;
                    }
                }

                if (boom)
                {
                    for (int j = 0; j < _blockPanelData.GetLength(1); j++)
                    {
                        _blockPanelData[i, j] = 0;
                    }

                    var copyPanelData = _blockPanelData.Clone() as int[,];
                    for (int j = 1; j <= i; j++) // 보이지않는 높이 2가 있다.
                    {
                        for (int k = 0; k < _blockPanelData.GetLength(1); k++)
                        {
                            copyPanelData[j, k] = _blockPanelData[j - 1, k];
                        }
                    }

                    _blockPanelData = copyPanelData.Clone() as int[,];
                }
            }
        }

        public bool IsGameOver()
        {
            for (int i = 0; i < PanelSettingHeight; i++)
            {
                for (int j = 0; j < PanelWidth; j++)
                {
                    if (_blockPanelData[i, j] == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [ExcludeFromCodeCoverage]
        public void UpdateTetrisView()
        {
            _updateTetrisView.Invoke(_blockPanelData);
        }

        public void PrintTetrisView()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < PanelHeight; i++)
            {
                for (int j = 0; j < PanelWidth; j++)
                {
                    sb.Append(_blockPanelData[i, j]);
                }

                sb.Append("\n");
            }

            Debug.Log(sb.ToString());
        }

        private void SetCurrentBlock(int number)
        {
            _currentBlock = (BlockKind) number switch
            {
                BlockKind.BlockI => new BlockI(),
                BlockKind.BlockO => new BlockO(),
                BlockKind.BlockJ => new BlockJ(),
                BlockKind.BlockL => new BlockL(),
                BlockKind.BlockS => new BlockS(),
                BlockKind.BlockT => new BlockT(),
                BlockKind.BlockZ => new BlockZ(),
                _ => throw new ArgumentOutOfRangeException(nameof(number), number, null)
            };
        }

        public void IntegrateBlockData()
        {
            _blockStackOnlyData = _blockPanelData.Clone() as int[,];
        }
    }
}
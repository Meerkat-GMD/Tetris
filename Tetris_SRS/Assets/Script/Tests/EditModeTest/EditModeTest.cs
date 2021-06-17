using JaeHeum;
using NUnit.Framework;
using UnityEngine;

namespace Test
{
    public class EditModeTest
    {
        [Test]
        public void TestTetrisChangeStateInitGame_IsGameStateTypeInitGame()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new InitGame());
            Assert.IsTrue(fakeTetris.GetGameStateForTest().GetType() == new InitGame().GetType());
        }
        
        [Test]
        public void TestTetrisChangeStateCreateBlock__IsGameStateTypeCreateBlock()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new CreateBlock());
            Assert.IsTrue(fakeTetris.GetGameStateForTest().GetType() == new CreateBlock().GetType());
        }
        
        [Test]
        public void TestTetrisChangeStatePutOnBlock_IsGameStateTypePutOnBlock()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new PutOnBlock());
            Assert.IsTrue(fakeTetris.GetGameStateForTest().GetType() == new PutOnBlock().GetType());
        }
        
        [Test]
        public void TestTetrisChangeStateEndGame_IsGameStateTypeEndGame()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new EndGame());
            Assert.IsTrue(fakeTetris.GetGameStateForTest().GetType() == new EndGame().GetType());
        }

        [Test]
        public void TestTetrisClear_IsDataEmpty()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            Assert.IsTrue(fakeTetris.IsTetrisDataEmptyForTest());
        }

        [Test]
        public void TestTetrisIntegrate_IsEqualBlockPanelDataAndBlockStackOnlyData()
        {
            var fakeTetris = new Tetris();
            fakeTetris.IntegrateBlockData();
            Assert.AreEqual(fakeTetris.GetBlockPanelDataForTest(),fakeTetris.GetBlockStackOnlyDataForTest());
        }

        [Test]
        public void TestTetrisSelectBlock_IsNotNull()
        {
            var fakeTetris = new Tetris();
            fakeTetris.SelectBlock();
            Assert.IsNotNull(fakeTetris.GetCurrentBlockForTest());
        }

        [Test]
        public void TestTetrisCreateBlock_CreateBlockI()
        {
            var check = CreateBlockTest(BlockKind.BlockI);
            Assert.IsTrue(check);
        }
        
        [Test]
        public void TestTetrisCreateBlock_CreateBlockO()
        {
            var check = CreateBlockTest(BlockKind.BlockO);
            Assert.IsTrue(check);
        }
        
        [Test]
        public void TestTetrisCreateBlock_CreateBlockJ()
        {
            var check = CreateBlockTest(BlockKind.BlockJ);
            Assert.IsTrue(check);
        }
        
        [Test]
        public void TestTetrisCreateBlock_CreateBlockL()
        {
            var check = CreateBlockTest(BlockKind.BlockL);
            Assert.IsTrue(check);
        }
        
        [Test]
        public void TestTetrisCreateBlock_CreateBlockS()
        {
            var check = CreateBlockTest(BlockKind.BlockS);
            Assert.IsTrue(check);
        }

        

        [Test]
        public void TestTetrisCreateBlock_CreateBlockT()
        {
            var check = CreateBlockTest(BlockKind.BlockT);
            Assert.IsTrue(check);
        }
        
        [Test]
        public void TestTetrisCreateBlock_CreateBlockZ()
        {
            var check = CreateBlockTest(BlockKind.BlockZ);
            Assert.IsTrue(check);
        }

        [Test]
        public void TestTetrisMoveDown_IsTrueBlockDownToBlank()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            
            fakeTetris.MoveBlockDown(out var success);
            
            Assert.IsTrue(success);
        }

        [Test]
        public void TestTetrisMoveDown_IsFalseBlockDownToBlock()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            
            fakeTetris.SetBlockStackOnlyDataForTest(out var inBlockPos,out var _);
            fakeTetris.SetCurrentBlockPositionForTest(inBlockPos);
            fakeTetris.MoveBlockDown(out var success);
            Assert.IsFalse(success);
        }

        [Test]
        public void TestTetrisRotate_IsTrueBlockRotationToBlank()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            
            var isRotate = fakeTetris.RotateBlock();
            Assert.IsTrue(isRotate);
        }
        
        [Test]
        public void TestTetrisRotate_IsFalseBlockRotationToBlock()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            
            fakeTetris.SetBlockStackOnlyDataForTest(out var inBlockPos,out var _);
            fakeTetris.SetCurrentBlockPositionForTest(inBlockPos);
            var isRotate = fakeTetris.RotateBlock();
            Assert.IsFalse(isRotate);
        }

        [Test]
        public void TestTetrisMoveHorizon_BlockMoveLeftToBlank_EqualBeforeMovePosition()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();

            var blockPos = fakeTetris.GetCurrentBlockPositionForTest();
            fakeTetris.MoveBlockHorizon(Tetris.Direction.Left);
            blockPos = new Vector2Int(blockPos.x-1, blockPos.y);
            Assert.AreEqual(blockPos,fakeTetris.GetCurrentBlockPositionForTest());
        }
        
        
        [Test]
        public void TestTetrisMoveHorizon_BlockMoveLeftToBlock_EqualBeforeMovePosition()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            fakeTetris.SetBlockStackOnlyDataForTest(out var inBlockPos,out var _);
            fakeTetris.SetCurrentBlockPositionForTest(inBlockPos);
            
            var blockPos = fakeTetris.GetCurrentBlockPositionForTest();
            fakeTetris.MoveBlockHorizon(Tetris.Direction.Left);
            Assert.AreEqual(blockPos,fakeTetris.GetCurrentBlockPositionForTest());
        }
        
        [Test]
        public void TestTetrisMoveHorizon_BlockMoveLeftToWall_EqualBeforeMovePosition()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            fakeTetris.SetCurrentBlockPositionForTest(new Vector2Int(0,0));
            
            var blockPos = fakeTetris.GetCurrentBlockPositionForTest();
            fakeTetris.MoveBlockHorizon(Tetris.Direction.Left);
            Assert.AreEqual(blockPos,fakeTetris.GetCurrentBlockPositionForTest());
        }
        
        [Test]
        public void TestTetrisMoveHorizon_BlockMoveRightToBlank_EqualBeforeMovePosition()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();

            var blockPos = fakeTetris.GetCurrentBlockPositionForTest();
            fakeTetris.MoveBlockHorizon(Tetris.Direction.Right);
            blockPos = new Vector2Int(blockPos.x+1, blockPos.y);
            Assert.AreEqual(blockPos,fakeTetris.GetCurrentBlockPositionForTest());
        }
        
        
        [Test]
        public void TestTetrisMoveHorizon_BlockMoveRightToBlock_EqualBeforeMovePosition()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();
            fakeTetris.SetBlockStackOnlyDataForTest(out var inBlockPos,out var _);
            fakeTetris.SetCurrentBlockPositionForTest(inBlockPos);
            
            var blockPos = fakeTetris.GetCurrentBlockPositionForTest();
            fakeTetris.MoveBlockHorizon(Tetris.Direction.Right);
            Assert.AreEqual(blockPos,fakeTetris.GetCurrentBlockPositionForTest());
        }

        [Test]
        public void TestTetrisMoveHorizon_BlockMoveRightToWall_EqualBeforeMovePosition()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SelectBlock();
            fakeTetris.CreateBlock();

            var shapeWidth = fakeTetris.GetCurrentBlockForTest().GetWidth();
            fakeTetris.SetCurrentBlockPositionForTest(new Vector2Int(Tetris.PanelWidth - shapeWidth, 0));

            var blockPos = fakeTetris.GetCurrentBlockPositionForTest();
            fakeTetris.MoveBlockHorizon(Tetris.Direction.Right);
            Assert.AreEqual(blockPos, fakeTetris.GetCurrentBlockPositionForTest());
        }

        [Test]
        public void TestTetrisBoomTetris_RemoveCanBoomLine_IsFalseAfterBoom()
        {
            var fakeTetris = new Tetris();

            fakeTetris.SetBlockPanelDataCheckBoomForTest();
            fakeTetris.BoomTetris();

            var canBoom = fakeTetris.CanBoomTetris();
            
            Assert.IsFalse(canBoom);
        }
        
        
        [Test]
        public void TestTetrisIntegrateData_IntegrateBetweenPanelDataAndStackOnlyData_IsSame()
        {
            var fakeTetris = new Tetris();
            fakeTetris.SetBlockPanelDataRandom();
            fakeTetris.IntegrateBlockData();
            
            Assert.AreEqual(fakeTetris.GetBlockPanelDataForTest(),fakeTetris.GetBlockStackOnlyDataForTest());
        }

        [Test]
        public void TestTetrisGameOver_DataUponPanelSettingHeight_IsTrue()
        {
            var fakeTetris = new Tetris();
            fakeTetris.SetBlockPanelDataCheckGameOverForTest();
            var isGameOver = fakeTetris.IsGameOver();
            Assert.IsTrue(isGameOver);
        }

        private bool CreateBlockTest(BlockKind blockKind)
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            fakeTetris.ResetBlockPosition();
            fakeTetris.SetCurrentBlockForTest((int) blockKind);
            fakeTetris.CreateBlock();
            fakeTetris.SetBlockData(out var success);

            var panelData = fakeTetris.GetBlockPanelDataForTest();
            var startPosition = fakeTetris.GetCurrentBlockPositionForTest();
            var block = fakeTetris.GetCurrentBlockForTest();
            var blockShape = block.GetBlockShape();
            var blockShapeX = block.GetWidth();
            var blockShapeY = block.GetHeight();

            var check = true;

            for (int i = startPosition.y; i < startPosition.y + blockShapeY; i++)
            {
                for (int j = startPosition.x; j < startPosition.x + blockShapeX; j++)
                {
                    if (panelData[i, j] != blockShape[i - startPosition.y, j - startPosition.x])
                    {
                        check = false;
                        break;
                    }
                }

                if (!check)
                {
                    break;
                }
            }

            return check;
        }
    }
}
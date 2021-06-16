using JaeHeum;
using NUnit.Framework;

namespace Test
{
    public class EditModeTest
    {
        // [Test]
        // public void TestTetrisInit()
        // {
        //     _fakeTetris.Init(null);
        //     _fakeTetris.ChangeState<Tetris>(new InitGame());
        //     Assert.IsTrue(_fakeTetris.GetGameState().GetType() == new InitGame().GetType());
        // }
        
        [Test]
        public void TestTetrisChangeStateInitGame_IsGameStateTypeInitGame()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new InitGame());
            Assert.IsTrue(fakeTetris.GetGameState().GetType() == new InitGame().GetType());
        }
        
        [Test]
        public void TestTetrisChangeStateCreateBlock__IsGameStateTypeCreateBlock()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new CreateBlock());
            Assert.IsTrue(fakeTetris.GetGameState().GetType() == new CreateBlock().GetType());
        }
        
        [Test]
        public void TestTetrisChangeStatePutOnBlock_IsGameStateTypePutOnBlock()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new PutOnBlock());
            Assert.IsTrue(fakeTetris.GetGameState().GetType() == new PutOnBlock().GetType());
        }
        
        [Test]
        public void TestTetrisChangeStateEndGame_IsGameStateTypeEndGame()
        {
            var fakeTetris = new Tetris();
            fakeTetris.ChangeState<Tetris>(new EndGame());
            Assert.IsTrue(fakeTetris.GetGameState().GetType() == new EndGame().GetType());
        }

        [Test]
        public void TestTetrisClear_IsDataEmpty()
        {
            var fakeTetris = new Tetris();
            fakeTetris.Clear();
            Assert.IsTrue(fakeTetris.IsTetrisDataEmpty());
        }

        [Test]
        public void TestTetrisIntegrate_IsEqualBlockPanelDataAndBlockStackOnlyData()
        {
            var fakeTetris = new Tetris();
            fakeTetris.IntegrateBlockData();
            Assert.AreEqual(fakeTetris.GetBlockPanelData(),fakeTetris.GetBlockStackOnlyData());
        }

        [Test]
        public void TestTetrisSelectBlock_IsNotNull()
        {
            var fakeTetris = new Tetris();
            fakeTetris.SelectBlock();
            Assert.IsNotNull(fakeTetris.GetCurrentBlock());
        }

        public void TestTetrisCreateBlock_CreateBlockI()
        {
            var fakeTetris = new Tetris();
            fakeTetris.SelectBlock();
        }
        
    }
}
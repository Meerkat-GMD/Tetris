using UnityEngine;

namespace JaeHeum
{
    public interface GameState<T> where T : Tetris
    {
        public void Enter(T tetris);
        public void Execute(T tetris);
        public void Exit(T tetris);
    }

    public class InitGame : GameState<Tetris>
    {
        public void Enter(Tetris tetris)
        {
            tetris.Clear();
        }

        public void Execute(Tetris tetris)
        {
            tetris.ChangeState<Tetris>(new CreateBlock());
        }

        public void Exit(Tetris tetris)
        {
        }
    }

    public class CreateBlock : GameState<Tetris>
    {
        public void Enter(Tetris tetris)
        {
            tetris.SelectBlock();
        }

        public void Execute(Tetris tetris)
        {
            tetris.CreateBlock();
            tetris.ChangeState<Tetris>(new DropBlock());
        }

        public void Exit(Tetris tetris)
        {
        }
    }

    public class DropBlock : GameState<Tetris>
    {
        public void Enter(Tetris tetris)
        {
            tetris.ResetBlockPosition();
            tetris.SetBlockData(out var success);
            if (!success)
            {
                tetris.ChangeState<Tetris>(new EndGame());
            }
        }

        public void Execute(Tetris tetris)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                tetris.RotateBlock();
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                tetris.MoveBlockDown(out var success);
                if (!success)
                {
                    tetris.ChangeState<Tetris>(new PutOnBlock());
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                tetris.MoveBlockHorizon(Tetris.Direction.Left);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                tetris.MoveBlockHorizon(Tetris.Direction.Right);
            }

            if (tetris.IsTimeToDown())
            {
                tetris.MoveBlockDown(out var success);
                if (!success)
                {
                    tetris.ChangeState<Tetris>(new PutOnBlock());
                }
            }

            tetris.UpdateTetrisView();
        }

        public void Exit(Tetris tetris)
        {
            tetris.ResetTimer();
        }
    }

    public class PutOnBlock : GameState<Tetris>
    {
        public void Enter(Tetris tetris)
        {
            tetris.IntegrateBlockData();
        }

        public void Execute(Tetris tetris)
        {
            if (tetris.IsGameOver())
            {
                tetris.ChangeState<Tetris>(new EndGame());
            }
            else
            {
                tetris.BoomTetris();
                tetris.IntegrateBlockData();
                tetris.ChangeState<Tetris>(new CreateBlock());
            }

            tetris.UpdateTetrisView();
        }

        public void Exit(Tetris tetris)
        {
        }
    }

    public class EndGame : GameState<Tetris>
    {
        public void Enter(Tetris tetris)
        {
            tetris.PrintTetrisView();
            Debug.Log("EndGame");
        }

        public void Execute(Tetris tetris)
        {
        }

        public void Exit(Tetris tetris)
        {
        }
    }
}
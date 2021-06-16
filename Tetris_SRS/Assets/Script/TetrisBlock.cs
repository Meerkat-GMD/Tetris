using System;

namespace JaeHeum
{
    public abstract class TetrisBlock
    {
        private IBlock _block;
    }

    public enum BlockKind
    {
        BlockI,
        BlockO,
        BlockJ,
        BlockL,
        BlockS,
        BlockT,
        BlockZ,
    }

    public interface IBlock
    {
        public void Create();
        public int[,] GetBlockShape();
        public int GetWidth();
        public int GetHeight();
        public void Rotation();

        public void ReverseRotation();

        public void Move();

        public void RotationFreeSet();
    }

    public class BlockI : IBlock
    {
        private int width = 4;
        private int height = 4;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {0, 0, 0, 0},
                {1, 1, 1, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
            });
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
            throw new NotImplementedException();
        }
    }

    public class BlockO : IBlock
    {
        private int width = 4;
        private int height = 4;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
            });
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
            throw new NotImplementedException();
        }
    }

    public class BlockJ : IBlock
    {
        private int width = 3;
        private int height = 3;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {1, 0, 0},
                {1, 1, 1},
                {0, 0, 0}
            });
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
        }
    }

    public class BlockL : IBlock
    {
        private int width = 3;
        private int height = 3;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {0, 0, 1},
                {1, 1, 1},
                {0, 0, 0}
            });
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
        }
    }

    public class BlockS : IBlock
    {
        private int width = 3;
        private int height = 3;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {0, 1, 1},
                {1, 1, 0},
                {0, 0, 0}
            });
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
        }
    }

    public class BlockT : IBlock
    {
        private int width = 3;
        private int height = 3;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {0, 1, 0},
                {1, 1, 1},
                {0, 0, 0}
            });
        }


        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
        }
    }

    public class BlockZ : IBlock
    {
        private int width = 3;
        private int height = 3;
        public int[,] blockShape;

        public void Create()
        {
            blockShape = (new int[,]
            {
                {1, 1, 0},
                {0, 1, 1},
                {0, 0, 0}
            });
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int[,] GetBlockShape()
        {
            return blockShape;
        }

        public void Rotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[height - 1 - j, i];
                }
            }
        }

        public void ReverseRotation()
        {
            var copyArray = blockShape.Clone() as int[,];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    blockShape[i, j] = copyArray[j, width - 1 - i];
                }
            }
        }

        public void Move()
        {
        }

        public void RotationFreeSet()
        {
        }
    }
}
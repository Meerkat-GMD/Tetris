using UnityEngine;

namespace JaeHeum
{
    public class TetrisManager : MonoBehaviour
    {
        [SerializeField] private TetrisView _tetrisView;
        private Tetris _tetris;

        private void Start()
        {
            _tetris = new Tetris();
            _tetris.Init(_tetrisView.UpdateTetrisView);
            _tetris.PrintTetrisView();
        }

        private void Update()
        {
            _tetris.Execute();
            _tetris.UpdateTetrisView();
        }

        public void Reset()
        {
            _tetris.Reset();
        }
    }
}
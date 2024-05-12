﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class FruitController : IInitializable, ILateDisposable
    {
        private Dictionary<Vector2Int, Fruit> _fruits = new Dictionary<Vector2Int, Fruit>();
        private GridController _gridController;
        private GameManager _gameManager;
        private int _countFruit;

        [Inject]
        private void Construct(GridController controller, GameManager gameManager)
        {
            _gridController = controller;
            _gameManager = gameManager;
            _gridController.OnCellEvent += CheckFruit;
        }

        public void LateDispose()
        {
            _gridController.OnCellEvent -= CheckFruit;
        }

        public void Initialize()
        {
            _fruits = _gridController._fruits;
            _countFruit = _fruits.Count;
        }

        private void CheckFruit(Cell cell)
        {
            if(_fruits.TryGetValue(cell._gridIndex, out Fruit findFruit))
            {
                findFruit.DeactivateFruit();
                _countFruit -= 1;
                if (_countFruit == 0)
                {
                    _gameManager.WinGame();
                }
            }
        }
    }
}
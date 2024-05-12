using Code;
using UnityEngine;
using Zenject;

namespace Code
{
    public class OpenPausePageButton : UIButton
    {
        [SerializeField] private string _pageId = "Pause";

        private PagesController _controller;
        private GameManager _gameManager;

        [Inject]
        private void Construct(PagesController pagesController, GameManager gameManager)
        {
            _controller = pagesController;
            _gameManager = gameManager;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _gameManager.PauseGame();
            _controller.ShowPage(_pageId);
        }
    }
}
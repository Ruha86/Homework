using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelNumberText : MonoBehaviour
    {
        public Text Text;
        public Text CurrentLevel;
        public Text NextLevel;

        public GameState GameState;

        private void Start()
        {
            CurrentLevel.text = (GameState.LevelIndex + 1).ToString();
            NextLevel.text = (GameState.LevelIndex + 2).ToString();


        }
    }
}
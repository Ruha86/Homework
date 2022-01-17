using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelNumberText : MonoBehaviour
    {
        public Text Text;
        public GameState GameState;

        private void Start()
        {
            Text.text = "Level " + (GameState.LevelIndex + 1).ToString();
        }
    }
}
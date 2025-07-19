using Unity.Mathematics;
using UnityEngine.Playables;
using UnityEngine;
using TMPro;

namespace extOSC.Examples
{
    public class FrqMinigolf : MonoBehaviour
    {
        [SerializeField] OSCReceiver oscReceiver;
        [SerializeField] GameObject arrowGO;
        [SerializeField] float goalScale;
        [SerializeField] TMP_Text goalText, scaleText, timerText;
        [SerializeField] PlayableDirector hitAnimation, missAnimation;

        private const string oscAddress = "/Frq";
        private float gameTimer, remappedScale;
        private int lastValue;

        void Start()
        {
            gameTimer = 10.0f;
            oscReceiver.Bind(oscAddress, MessageReceived);
        }

        void MessageReceived(OSCMessage message)
        {
            if (message.ToFloat(out var value))
            {
                remappedScale = math.remap(0.0f, goalScale, 0.0f, 1.0f, value);
                arrowGO.transform.localScale = new Vector3(remappedScale, 1, 1);
                lastValue = Mathf.RoundToInt(value);
                scaleText.text = lastValue.ToString() + " Hz";
            }
        }

        void GolfSwing()
        {
            if (goalScale > lastValue - 30 && goalScale < lastValue + 30)
            {
                hitAnimation.Play();
            } else {
                missAnimation.Play();
            }

            gameTimer = 10.0f;
            goalScale = UnityEngine.Random.Range(100.0f, 500.0f);
            goalText.text = "Goal: " + Mathf.RoundToInt(goalScale).ToString() + " Hz";
        }

        void Update()
        {
            if (gameTimer > 0)
            {
                gameTimer -= Time.deltaTime;
                timerText.text = Mathf.RoundToInt(gameTimer).ToString();
            }
            else
            {
                GolfSwing();

            }
        }
    }
}

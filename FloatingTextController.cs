using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace QFramework.Example
{
    public partial class FloatingTextController : ViewController
    {
        public static FloatingTextController _instance;
        private void Awake()
        {
            _instance = this;
        }
        void Start()
        {
            FloatingText.Hide();
        }
        /// <summary>
        /// 受伤悬浮
        /// </summary>
        /// <param name="position">悬浮位置</param>
        /// <param name="text">显示文本</param>
        public static void Play(Vector2 position, string text)
        {
            _instance.FloatingText.InstantiateWithParent(_instance.transform)
                .Position(position.x, position.y)
                .Self(f =>
            {
                var positionY = position.y;
                var textTrans = f.transform.Find("Text");
                var textComp = textTrans.GetComponent<Text>();
                textComp.text = text;
                ActionKit.Sequence()
                .Lerp(0, 0.5f, 0.5f, (p) =>
                {
                    f.PositionY(positionY + p * 0.25f);
                    textComp.LocalScaleX(Mathf.Clamp01(p * 8));
                    textComp.LocalScaleY(Mathf.Clamp01(p * 8));
                })
                .Delay(0.5f)
                .Lerp(1f, 0, 0.3f, (p) => { textComp.ColorAlpha(p); },
                () =>
                {
                    textTrans.DestroyGameObjGracefully();
                }).Start(textComp);
            }).Show();
        }
        private void OnDestroy()
        {
            _instance = null;
        }

    }
}

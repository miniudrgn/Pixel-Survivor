using UnityEngine;
using QFramework;


namespace QFramework.Example
{
    public partial class FxController : ViewController
    {
        private static FxController _instance;
        private void Awake()
        {
            _instance = this;
        }
        private void OnDestroy()
        {
            _instance = null;
        }
        public static void Play(SpriteRenderer sprite, Color dissolveColor)
        {
            _instance.EnemyDieFx.Instantiate()
                .Position(sprite.Position())
                .LocalScale(sprite.LocalScale())
                .Self(s =>
                {
                    s.GetComponent<Dissolve>().DissolveColor = dissolveColor;
                    s.sprite = sprite.sprite;
                }).Show();
        }
    }
}

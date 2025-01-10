using UnityEngine;
using QFramework;

namespace QFramework.Example
{
    public partial class Player : ViewController
    {
        public float moveSpeed = 5f;
        public static Player player;
        private void Awake()
        {
            player = this;
        }
        private void OnDestroy()
        {
            player = null;
        }
        void Start()
        {
            HurtBox.OnTriggerEnter2DEvent(collider2D =>
            {
                var hitBox = collider2D.GetComponent<HitBox>();
                if (hitBox)
                {
                    if (hitBox.owner.CompareTag("Enemy"))
                    {
                        Global.HP.Value--;
                        if (Global.HP.Value<=0)
                        {
                            this.DestroyGameObjGracefully();
                            UIKit.OpenPanel<TestUIGameOverPanel>();
                            AudioKit.PlaySound("Die");
                        }
                        else
                        {
                            AudioKit.PlaySound("Hurt");
                        }
                    }
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            void UpdateHP()
            {
                HPValue.fillAmount = Global.HP.Value / (float)Global.MaxHP.Value;
            }
            Global.HP.RegisterWithInitValue(hp =>
            {
                UpdateHP();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            Global.MaxHP.RegisterWithInitValue(maxHP =>
            {
                UpdateHP(); 
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        private void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            //normalized让斜着走的速度也为1，而不是根号2
            Vector2 target = new Vector2(x, y).normalized * moveSpeed;
            rb.velocity = Vector2.Lerp(rb.velocity, target, 1 - Mathf.Exp(-Time.deltaTime * 5));
        }
    }
}

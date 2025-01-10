using UnityEngine;
using QFramework;


namespace QFramework.Example
{
	public partial class Exp : ViewController
	{
        public bool isGet;
        private float moveSpeed = 4f;
        /// <summary>
        /// 碰撞到有CollectableArea组件执行
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<CollectableArea>())
            {
                AudioKit.PlaySound("Exp");
                Global.Exp.Value++;
                this.DestroyGameObjGracefully();
            }
        }
        private void FixedUpdate()
        {
            if (isGet)
            {
                GetAllexp();
                //isGet = false;
            }
        }
        public void GetAllexp()
        {
            if (Player.player)
            {
                Vector3 direction = (Player.player.transform.position - transform.position).normalized;
                rb.velocity = direction * moveSpeed;
            }
        }
    }
}

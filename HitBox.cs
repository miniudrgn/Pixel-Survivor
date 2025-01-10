using UnityEngine;
using QFramework;

namespace QFramework.Example
{
	public partial class HitBox : ViewController
	{
		public GameObject owner;
        private void Start()
        {
            if (!owner)
            {
                owner = transform.parent.gameObject;
            }
        }
    }
}

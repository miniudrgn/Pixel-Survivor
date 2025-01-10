using UnityEngine;
using QFramework;

namespace QFramework.Example
{
	public partial class HurtBox : ViewController
	{
		public GameObject Ower;
		void Start()
		{
			if (!Ower)
			{
				Ower = transform.parent.gameObject;
			}
		}
	}
}

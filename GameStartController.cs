using UnityEngine;
using QFramework;

namespace QFramework.Example
{
	public partial class GameStartController : ViewController
	{
        void Start()
		{
			UIKit.OpenPanel<UIGameStartPanel>();
		}
	}
}

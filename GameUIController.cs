using UnityEngine;
using QFramework;

namespace QFramework.Example
{
	public partial class GameUIController : ViewController
	{
		void Start()
		{
			UIKit.OpenPanel<UIGamePanel>();
		}
        private void OnDestroy()
        {
            UIKit.ClosePanel<UIGamePanel>();	 
        }
    }
}

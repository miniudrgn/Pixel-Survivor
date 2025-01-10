using UnityEngine;
using Cinemachine;
using QFramework;


namespace QFramework.Example
{
	public partial class CameraController : ViewController
	{
		public static CameraController Default = null;
        public static Transform LBTrans => Default.LB;
        public static Transform RTTrans => Default.RT;
        private CinemachineConfiner2D confiner2D;
        private void Awake()
        {
            Default = this;
            confiner2D = GetComponent<CinemachineConfiner2D>();
        }
        private void OnDestroy()
        {
            Default = null;
        }	

        void Start()
		{
            SwitchConfinerShape();
        }
        private void Update()
        {

        }
        /// <summary>
        /// 设置摄像机走动边缘
        /// </summary>
        private void SwitchConfinerShape()
		{
            var obj = GameObject.FindGameObjectWithTag("Bounds");
            if (obj == null)
                return;
            confiner2D.m_BoundingShape2D = obj.GetComponent<Collider2D>();
            confiner2D.InvalidateCache();
        }
        public void Shake()
        {
            CameraShake.GenerateImpulse();
        }
	}
}

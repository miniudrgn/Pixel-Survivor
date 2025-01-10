using UnityEngine;
using QFramework;
using System;
using System.Collections.Generic;
using static QFramework.Example.EnemySpawn;
using Random = UnityEngine.Random;

namespace QFramework.Example
{

 
    public partial class EnemySpawn : ViewController
    {
        [SerializeField]
        public EnemyWaveConfig Config;
        /// <summary>
        /// �������ɼ�ʱ
        /// </summary>
        private float mCurrentSeconds;
        /// <summary>
        /// ���˲�����ʱ
        /// </summary>
        private float mCurrentWaveSeconds;
        /// <summary>
        /// ��������
        /// </summary>
        public static BindableProperty<int> enemyCount = new BindableProperty<int>(0);
        /// <summary>
        /// ���˶���
        /// </summary>
        private Queue<EnemyWave> enemyWavesQueue = new Queue<EnemyWave>();
        public int waveCount = 0;
        private int totalCount = 0;
        //��Ⲩ���Ƿ�������
        public bool LastWave => waveCount == totalCount;
        public EnemyWave CurrentWave => currentWave;
        private void Start()
        {
            foreach (var group in Config.EnemyWaveGroup)
            {
                foreach (var wave in group.Waves)
                {
                    enemyWavesQueue.Enqueue(wave);
                    totalCount++;
                }
            }
        }
        private EnemyWave currentWave = null;   
        private void Update()
        {
            if (currentWave == null)
            {
                if (enemyWavesQueue.Count > 0)
                {
                    waveCount++;
                    //ɾ�����е�һ�����ĵ��˲������������ڲ�������ʱ
                    currentWave = enemyWavesQueue.Dequeue();
                    mCurrentSeconds = 0;
                    mCurrentWaveSeconds = 0;
                }   
            }
            else if (currentWave != null)  
            {
                mCurrentSeconds += Time.deltaTime;
                mCurrentWaveSeconds += Time.deltaTime;
                if (mCurrentSeconds >= currentWave.spawnDuration)
                {
                    //1������һ������
                    mCurrentSeconds = 0;
                    var Default = Player.player;
                    if(Default)
                    {
                        //����Χ���������Ե����
                        var xOry = RandomUtility.Choose(-1, 1);
                        var pos = Vector2.zero;
                        if (xOry == -1)
                        {
                            pos.x = RandomUtility.Choose(CameraController.LBTrans.position.x, CameraController.RTTrans.position.x);
                            pos.y = Random.Range(CameraController.LBTrans.position.y, CameraController.RTTrans.position.y);
                        }
                        else
                        {
                            pos.x = Random.Range(CameraController.LBTrans.position.x, CameraController.RTTrans.position.x);
                            pos.y = RandomUtility.Choose(CameraController.LBTrans.position.y, CameraController.RTTrans.position.y);
                        }
                        currentWave.enemyPrefabs.Instantiate()
                            .Position(pos)
                            .Self(self =>
                            {
                                var enemy = self.GetComponent<IEnemy>();
                                enemy.SetSpeedScale(currentWave.SpeedScale);
                                enemy.SetHPScale(currentWave.HPScale);
                            })
                            .Show();
                    }    
                }
                if (mCurrentWaveSeconds >= currentWave.Seconds)
                {
                    currentWave = null;
                }
            }
        }
    }
}

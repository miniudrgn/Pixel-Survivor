using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.Example
{
    [CreateAssetMenu]
    public class EnemyWaveConfig : ScriptableObject
    {
        [SerializeField]
       public List<EnemyWaveGroup> EnemyWaveGroup = new List<EnemyWaveGroup>(); 
    }
    [Serializable]
    public class EnemyWaveGroup
    {
        public string Name;
        [TextArea]
        public string Description =string.Empty;
        [SerializeField]
        public List<EnemyWave> Waves = new List<EnemyWave>();    
    }
    [Serializable]
    public class EnemyWave
    {
        /// <summary>
        /// 敌人姓名
        /// </summary>
        public string Name;
        /// <summary>
        /// 判断波次
        /// </summary>
        public bool Active = true;
        /// <summary>
        /// 敌人生成间隔时间
        /// </summary>
        public float spawnDuration = 1f;
        public GameObject enemyPrefabs;
        /// <summary>
        /// 波数间隔时间
        /// </summary>
        public int Seconds = 30;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float SpeedScale = 1f;
        /// <summary>
        /// 血量
        /// </summary>
        public float HPScale = 1f;
    }
}


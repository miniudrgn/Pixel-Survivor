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
        /// ��������
        /// </summary>
        public string Name;
        /// <summary>
        /// �жϲ���
        /// </summary>
        public bool Active = true;
        /// <summary>
        /// �������ɼ��ʱ��
        /// </summary>
        public float spawnDuration = 1f;
        public GameObject enemyPrefabs;
        /// <summary>
        /// �������ʱ��
        /// </summary>
        public int Seconds = 30;
        /// <summary>
        /// �ƶ��ٶ�
        /// </summary>
        public float SpeedScale = 1f;
        /// <summary>
        /// Ѫ��
        /// </summary>
        public float HPScale = 1f;
    }
}


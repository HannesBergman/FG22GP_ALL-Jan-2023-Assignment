using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Variables
{
    [CreateAssetMenu(fileName = "new SpawnPosIndex", menuName = "ScriptableObjects/Variables/SpawnPosIndex")]
    public class SpawnPosIndexScriptableGameObject : ScriptableObject
    {
        [Range(1, 5)]
        [SerializeField] public int _value;

        public int Value => _value;
    }
}



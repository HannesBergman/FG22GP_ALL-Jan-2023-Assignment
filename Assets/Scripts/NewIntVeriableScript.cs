using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Variables
{
    [CreateAssetMenu(fileName = "new IntVeriableLikeFloatVariable", menuName = "ScriptableObjects/Variables/IntVeriableLikeFloatVariable")]
    public class NewIntVeriableScript : ScriptableObject
    {
        [Range(0, 10)]
        [SerializeField] public int _value;

        public int Value => _value;
    }
}



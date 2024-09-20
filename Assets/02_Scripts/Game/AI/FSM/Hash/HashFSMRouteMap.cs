using System.Collections.Generic;
using UnityEngine;

namespace FSM.Hash
{

    [CreateAssetMenu(menuName = "SO/AI/FSM/Hash")]
    public class HashFSMRouteMap : ScriptableObject
    {

        /// <summary>
        /// 스테이트 이름들
        /// </summary>
        public List<string> states;

        /// <summary>
        /// 스테이트 들
        /// </summary>
        public List<HashStateBase> stateObjects;

    }

}
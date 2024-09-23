using System.Collections.Generic;
using UnityEngine;

namespace FSM.Hash
{

    [System.Serializable]
    public class HashFSMRouteMap
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
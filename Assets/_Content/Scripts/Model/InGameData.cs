using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tinker
{
    [Serializable]
    public class InGameData
    {
        public string levelId;
        public List<string> ObjectFounds = new List<string>();
        public int totalHiddenObjects;
        public int ObjectFoundCount => ObjectFounds.Count;
        
        public bool IsLevelComplete => ObjectFoundCount == totalHiddenObjects;

        public void AddFoundHiddenObject(string id)
        {
            if (!ObjectFounds.Contains(id))
            {
                ObjectFounds.Add(id);
            }
        }
    }
}

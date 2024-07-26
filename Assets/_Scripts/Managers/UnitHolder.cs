using System.Collections.Generic;
using Assets.Unit;
using Assets.Utilities;

namespace Assets._Scripts.Managers
{
    public class UnitHolder : ScenewideSingleton<UnitHolder>
    {
        public List<UnitScript> Units;

        public UnitScript UnitTestPref;

        public void Start()
        {
        }
    }
}
using UnityEngine;
using Assets.Scripts.Unit;

namespace Assets.Scripts.Components
{
    public class GridManager : MonoBehaviour
    {
        private CellScript _c;
        private CellScript _pc;
        private UnitBase _unit;

        private void Start()
        {
            Application.targetFrameRate = 60;
            _unit = Resources.Load<UnitBase>("UnitBase");
            InvokeRepeating(nameof(UpdateC), 0, 0.1f);
        }

        private void Update()
        {
            _unit.Stats.HP.Value++;
        }

        private void UpdateC()
        {
            var c = transform
                .GetChild(Random.Range(0, transform.childCount - 1))
                .GetComponent<CellScript>();
            c.Unit.Value = _unit;
            _pc = _c;
            _c = c;

            if (_pc != null && _pc != _c)
                _pc.Unit.Value = null;
        }
    }
}
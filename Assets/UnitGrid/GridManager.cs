using System.Collections.Generic;
using Assets._Scripts.Managers;
using UnityEngine;

namespace Assets.UnitGrid
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private UnitGridSettings _gridSettings;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private UnitHolder _unitHolder;

        [HideInInspector] public Dictionary<Vector3, Cell> Cells { get; } = new();

        private void Start()
        {
            GenerateCells();
            PlaceUnits();
        }

        private void GenerateCells()
        {
            for (var row = 0; row < _gridSettings.Rows; row++)
            {
                for (var column = 0; column < _gridSettings.Columns; column++)
                {
                    var spawningCell = Instantiate(_cellPrefab, transform);
                    spawningCell.name = $"Cell [{row}, {column}]";
                    spawningCell.Row = row;
                    spawningCell.Column = column;
                    Cells.Add(new(row, column), spawningCell);
                }
            }
        }

        private void PlaceUnits()
        {
            foreach (var unit in _unitHolder.Units)
            {
                Cells[new(unit.Stats.GridRow, unit.Stats.GridColumn)].Unit.Value = unit;
            }
        }
    }
}
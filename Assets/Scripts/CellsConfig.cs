using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Units.Base;
using R3;

namespace Assets.Scripts
{
    public class CellsScript : MonoBehaviour
    {
        [field: SerializeField] public int Row { get; private set; }
        [field: SerializeField] public int Column { get; private set; }
        [field: SerializeField] public int AttackText { get; private set; }
        [field: SerializeField] public int HPText { get; private set; }
        [field: SerializeField] public int InitText { get; private set; }
        [field: SerializeField] public int MnvrText { get; private set; }
        [field: SerializeField] public ReactiveProperty<UnitBase> Unit { get; set; }

        private readonly List<IDisposable> _statSubscriptions = new();

        //GetComponent<TMPro.TextMeshProUGUI>().text
        private void Start()
        {
            Unit.Subscribe(SubscribeToUnitChanges);
        }

        public void SubscribeToUnitChanges(UnitBase newUnit)
        {
            //удаляем старые подписки, чтобы старый юнит не обновлял клетку
            foreach (var sub in _statSubscriptions)
            {
                sub?.Dispose();
            }
            _statSubscriptions.Clear();

            //добавляем все подписки статов нового юнита в коллекцию
            _statSubscriptions.Add(newUnit.Stats.MaxHP.Subscribe(HpChanged));
        }

        private void HpChanged(int newHP)
        {
            //
        }
    }
}

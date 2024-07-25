using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Unit;
using R3;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.Components
{
    public class CellScript : MonoBehaviour
    {
        private Image _unitPlace;
        private Image _cellSprite;
        private TextMeshProUGUI _attack;
        private TextMeshProUGUI _hp;
        private TextMeshProUGUI _mnvr;
        private TextMeshProUGUI _init;

        [SerializeField] private Sprite _empty;
        [SerializeField] private Sprite _filled;

        private readonly List<IDisposable> _statSubscriptions = new List<IDisposable>();

        [field: SerializeField] public int Row { get; private set; }
        [field: SerializeField] public int Column { get; private set; }

        public SerializableReactiveProperty<UnitBase> Unit = new(null);

        private void Start()
        {
            _cellSprite = GetComponent<Image>();
            _unitPlace = transform.Find("UnitPlace").GetComponent<Image>();
            _attack = transform.Find("AttackValue").GetComponent<TextMeshProUGUI>();
            _hp = transform.Find("HPValue").GetComponent<TextMeshProUGUI>();
            _mnvr = transform.Find("MnvrValue").GetComponent<TextMeshProUGUI>();
            _init = transform.Find("InitValue").GetComponent<TextMeshProUGUI>();
            Unit.Pairwise().Subscribe(UnitChanged);
        }

        private void UnitChanged((UnitBase Old, UnitBase New) unit)
        {
            if (unit.Old is not null)
            {
                UnsubscribeFromStatChanges();
                _cellSprite.sprite = _empty;
                _unitPlace.sprite = null;
                _unitPlace.color = new Color(0, 0, 0, 0);

                unit.Old.CellRow = -1;
                unit.Old.CellColumn = -1;
                _attack.text = string.Empty;
                _hp.text = string.Empty;
                _mnvr.text = string.Empty;
                _init.text = string.Empty;
            }

            if (unit.New is not null)
            {
                SubscribeToStatChanges(unit.New.Stats);
                _cellSprite.sprite = _filled;
                _unitPlace.sprite = unit.New.Sprite;
                _unitPlace.color = new Color(255, 255, 255, 255);

                unit.New.CellRow = Row;
                unit.New.CellColumn = Column;

                _attack.text = unit.New.Stats.Attack.Value.ToString();
                _hp.text = unit.New.Stats.HP.Value.ToString();
                _mnvr.text = unit.New.Stats.ManeuversAmount.Value.ToString();
                _init.text = unit.New.Stats.Initiative.Value.ToString();
            }
        }

        private void SubscribeToStatChanges(UnitStats stats)
        {
            _statSubscriptions.Add(stats.Attack.Subscribe(atk => _attack.text = atk.ToString()));
            _statSubscriptions.Add(stats.HP.Subscribe(hp => _hp.text = hp.ToString()));
            _statSubscriptions.Add(stats.Initiative.Subscribe(init => _init.text = init.ToString()));
            _statSubscriptions.Add(stats.ManeuversAmount.Subscribe(mnvr => _mnvr.text = mnvr.ToString()));
        }

        private void UnsubscribeFromStatChanges()
        {
            foreach (var sub in _statSubscriptions)
            {
                sub?.Dispose();
            }
            _statSubscriptions.Clear();
        }
    }
}

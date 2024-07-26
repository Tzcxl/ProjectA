using System;
using System.Collections.Generic;
using UnityEngine;
using R3;
using UnityEngine.UI;
using TMPro;
using Assets.Unit;
using Assets.Unit.Stats;

namespace Assets.UnitGrid
{
    public class Cell : MonoBehaviour
    {
        private Image _unitPlace;
        private TextMeshProUGUI _attack;
        private TextMeshProUGUI _hp;
        private TextMeshProUGUI _mnvr;
        private TextMeshProUGUI _init;

        [SerializeField] private Image _cellSprite;
        [SerializeField] private Image _unitSprite;

        [SerializeField] private Sprite _empty;
        [SerializeField] private Sprite _filled;

        private readonly List<IDisposable> _statSubscriptions = new List<IDisposable>();

        public int Row { get; set; }
        public int Column { get; set; }

        public SerializableReactiveProperty<UnitScript> Unit = new(null);

        private void Start()
        {
            _unitPlace = transform.Find("UnitPlace").GetComponent<Image>();
            _attack = transform.Find("AttackValue").GetComponent<TextMeshProUGUI>();
            _hp = transform.Find("HPValue").GetComponent<TextMeshProUGUI>();
            _mnvr = transform.Find("MnvrValue").GetComponent<TextMeshProUGUI>();
            _init = transform.Find("InitValue").GetComponent<TextMeshProUGUI>();
            Unit.Pairwise().Subscribe(UnitChanged);
        }

        private void UnitChanged((UnitScript Old, UnitScript New) unit)
        {
            if (unit.Old is not null)
            {
                UnsubscribeFromStatChanges();
                _cellSprite.sprite = _empty;
                _unitPlace.sprite = null;
                _unitPlace.color = new Color(0, 0, 0, 0);

                unit.Old.Stats.GridRow = -1;
                unit.Old.Stats.GridColumn = -1;
                _attack.text = string.Empty;
                _hp.text = string.Empty;
                _mnvr.text = string.Empty;
                _init.text = string.Empty;
            }

            if (unit.New is not null)
            {
                SubscribeToStatChanges(unit.New.Stats);
                _cellSprite.sprite = _filled;
                _unitPlace.sprite = unit.New.Stats.Sprite;
                _unitPlace.color = new Color(255, 255, 255, 255);

                unit.New.Stats.GridRow = Row;
                unit.New.Stats.GridColumn = Column;

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

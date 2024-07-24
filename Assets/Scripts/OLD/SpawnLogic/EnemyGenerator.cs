using System.Collections.Generic;
using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGenerator : MonoBehaviour
{
    private UnitConfig warConfig;
    private UnitBase allConfig;
    private UnitConfig archConfig;
    private List<GameObject> units = new List <GameObject>();
    private List<int> Initiative = new List<int>();


    public VisualTreeAsset myVisualTreeAsset;
    public GameObject warPrefab;
    public GameObject archPrefab;


    void OnEnable()
    {
        allConfig = Resources.Load<UnitBase>("UnitBase");
        warConfig = Resources.Load<UnitConfig>("WarConf");
        archConfig = Resources.Load<UnitConfig>("ArchConf");

        var document = GetComponent<UIDocument>();
        var root = document.rootVisualElement;
        myVisualTreeAsset.CloneTree(root);
        var Enemy1row = root.Q<VisualElement>("Enemy1row");
        var buttons = Enemy1row.Query<Button>().ToList();
        var labels = Enemy1row.Query<Label>().ToList();
        int i = 1;

        foreach (var button in buttons)
        {
            GetImage(button,archPrefab);
            archPrefab.name = $"E{i}";
            units.Add(archPrefab);
        }
        
        foreach (var label in labels)
        {
            UpdateCharacterStatsLabel(label,archConfig);
        }

        var Player1row = root.Q<VisualElement>("Player1row");
        var Pbuttons = Player1row.Query<Button>().ToList();
        var Plabels = Player1row.Query<Label>().ToList();
        i = 1;

        foreach (var button in Pbuttons)
        {
            if (i == 1)
            {
                GetImage(button, warPrefab);
                warPrefab.name = $"P{i}";
                units.Add(warPrefab);
                i++;
            }
            else
            {
                GetImage(button, archPrefab);
                archPrefab.name = $"P{i}";
                units.Add(archPrefab);
            }
        }
         i = 1;
        foreach (var label in Plabels)
        {
            if (i == 1)
            {
                UpdateCharacterStatsLabel(label,warConfig);
                i++;
            }
            else
            {
                UpdateCharacterStatsLabel(label,archConfig);
            }
        }
    }


    public void GetImage(Button button, GameObject pref)
    {
        SpriteRenderer spriteRenderer = pref.GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer.sprite;
        Texture2D texture = sprite.texture;
        var styleBackground = new StyleBackground(texture);
        button.style.backgroundImage = styleBackground;
    }

    void UpdateCharacterStatsLabel(Label label,UnitConfig unitconf)
    {
        label.text = $"{unitconf.unitName}\nHP: {unitconf.unitHP}\nAttack: {unitconf.unitDamage}\nInit: {unitconf.unitInitiative}";
        label.style.fontSize = 10; 
        label.style.color = Color.white; 
    }
}


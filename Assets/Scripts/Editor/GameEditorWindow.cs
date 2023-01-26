using Asteroids;
using Ship;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Variables;

public class GameEditorWindow : EditorWindow
{
    public Slider rotationSpeedSlider;
    public DropdownField spawnPosition;
    public Slider astroidDamageSlider;
    public IntegerField shipHealthField;

    [SerializeField] private FloatVariable _throttlePower;
    [SerializeField] private FloatVariable _rotationPower;
    [SerializeField] private NewIntVeriableScript _newIntVeriable;
    [SerializeField] private SpawnPosIndexScriptableGameObject _spawnPosIndex;
    [SerializeField] private IntVariable _shipHealth;
    //[SerializeField] private Hull _hull;
    //[SerializeField] private GameObject _ship;


    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/GameEditorWindow")]
    public static void ShowExample()
    {
        GameEditorWindow wnd = GetWindow<GameEditorWindow>();
        wnd.titleContent = new GUIContent("GameEditorWindow");
    }
    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        //_astroidDamage = _ship.GetComponent<Hull>()._astroidDamage;

        rotationSpeedSlider = root.Q<Slider>("RotationSpeed");
        spawnPosition = root.Q<DropdownField>("AstroidSpawnDirection");
        astroidDamageSlider = root.Q<Slider>("AstroidDamage");
        shipHealthField = root.Q<IntegerField>("ShipHealth");

        rotationSpeedSlider.RegisterValueChangedCallback(OnRotationSpeedSliderChangedEvent);
        spawnPosition.RegisterValueChangedCallback(OnDropdownFieldChangedEvent);
        astroidDamageSlider.RegisterValueChangedCallback(OnAstroidDamageSliderChangedEvent);
        shipHealthField.RegisterValueChangedCallback(OnShipHealthFieldChangedEvent);
    }
    private void OnRotationSpeedSliderChangedEvent(ChangeEvent<float> evt)
    {
        var newValue = evt.newValue;
        _rotationPower._value = newValue;
    }

    private void OnAstroidDamageSliderChangedEvent(ChangeEvent<float> evt)
    {
        var newValue = evt.newValue;
        _newIntVeriable._value = (int)newValue;
        
    }
    private void OnShipHealthFieldChangedEvent(ChangeEvent<int> evt)
    {
        var newValue = evt.newValue;
        _shipHealth._value = newValue;
    }
    private void OnDropdownFieldChangedEvent(ChangeEvent<string> evt)
    {
        var newValue = evt.newValue;

        if (newValue == "Bottom")
        {
            _spawnPosIndex._value = 1;
        }
        else if (newValue == "Left")
        {
            _spawnPosIndex._value = 2;
        }
        else if (newValue == "Right")
        {
            _spawnPosIndex._value = 3;
        }
        else if (newValue == "Top")
        {
            _spawnPosIndex._value = 4;
        }
        else
        {
            _spawnPosIndex._value = 5;
        }
    }
}

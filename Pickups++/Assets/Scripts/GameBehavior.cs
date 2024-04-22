using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;
using UnityEngine.UIElements;
using TMPro;

public class GameBehavior : MonoBehaviour, Imanager
{


    public delegate void DebugDelegate(string newText);

    public DebugDelegate debug = Print;
    public Camera cam;
    public GameObject player;
    public GameObject jumpscare;
    private int _keysCollected = 0;
    private int _currentKeys = 0;
    private int _locksRemaining = 3;
    
    public int maxKeys = 3;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public PlayerBehavior Player;
    private int currentHP;
    public Stack<string> lootStack = new Stack<string>();
    private string _state;
    private bool _buttonPressed = false;
    public Gate2Behavior g2b;

    string _labelText = "Collect all 3 keys to unlock the gate and escape!";
    [SerializeField] TextMeshProUGUI labelText;
    public string LabelText
    {
        get
        {
            return _labelText;
        }
        set
        {
            _labelText = value;
            labelText.text = $"{_labelText}";
        }
    }

    public string State
    {
        get { return _state; }

        set { _state = value; }
    }
    void Start()
    {
        Initialize(); 
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.Item);
        LabelText = _labelText;
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);
        debug(_state);
        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
        LogWithDelegate(debug);
        
    }

    
    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!",lootStack.Count);
    }
    public static void Print(string newText)
    {
        Debug.Log(newText);
    }
    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task");
    }
    public bool ButtonPressed
    {
        get { return _buttonPressed; }

        set
        {
            _buttonPressed = value;
            if(_buttonPressed )
            {
                LabelText = "Woah a gun! wait what's that noise?";
                g2b.OpenGate();
                GameObject.Find("EnemyGroup").SetActive(true);
                GameObject.Find("Revolver").SetActive(true);

            }
        }
    }
    public int Keys
    {
        get { return _keysCollected; }

        set 
        { 
            _keysCollected = value;
            
            if (_keysCollected >= maxKeys)
            {
                LabelText = "You've found all the keys! Go unlock the gate!";
                
            }
            else
            {
                LabelText = "Key found, only " + (maxKeys - _keysCollected) + " more to go.";
            }
        }
        

    }
    public int Locks
    {
        get { return _locksRemaining; }

        set
        {
            _locksRemaining = value;

            if (_locksRemaining == 0)
            {

                LabelText = "The Gate is open! Let's get out of here!";
            }
        }
    }
    public int HP
    {
        get { return currentHP; }

        set
        {
            currentHP = value;
            if (currentHP <= 0)
            {
                LabelText = "You died. Try again?";
                Jumpscare();
            }
            if (currentHP > 1)
            {
                LabelText = "You feel invigorated.";
            }
        }
    }

    public int currentKeys
    {
        get { return _currentKeys; }

        set
        {
            _currentKeys = value;
            if (_currentKeys == 0)
            {
                Player.hasKey = false;
            }
            if(_currentKeys > 0)
            {
                Player.hasKey = true;
            }
        }
    }
    public void Showloss()
    {
        showLossScreen = true;
    }
    public void Jumpscare()
    {
        jumpscare.SetActive(true);
        Player.cameraCanMove = false;
        Player.playerCanMove = false;
        cam.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20,50,150,25), "Keys Collected:" + _keysCollected);

        
        if (showLossScreen)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50,200,100),"You died."))
            {
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Level restarted successfully");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug($"Reverting to scene 0: {e.ToString()}");
                }
                finally
                {
                    debug("Restart handled");
                }
            }
        }
        if(showWinScreen) {
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            if (GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"You Escaped!"))
            {
                Utilities.RestartLevel();
            }
        }
    }
    
}

using TMPro;
using UnityEngine;

public class NameHandler : MonoBehaviour
{
    public static NameHandler nameHandler;
    
    [SerializeField]
    private TMP_InputField inputName;
    private string playerName;
    private string defaultName = "U-KNIGHT";

    private void Awake()
    {
        if (nameHandler == null)
        {
            nameHandler = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (inputName.text == null || inputName.text.Equals(""))
        {
            inputName.text = defaultName;
            playerName = defaultName;
        }

        if (!playerName.Equals(inputName.text))
            playerName = inputName.text;
    }
    
    public static string InputName
    {
        get { return nameHandler.inputName.text; }
        set { nameHandler.inputName.text = value; }
    }

    public static string PlayerName
    {
        get { return nameHandler.playerName; }
        set { nameHandler.playerName = value; }
    }
}

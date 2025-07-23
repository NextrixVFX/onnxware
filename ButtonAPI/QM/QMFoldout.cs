using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace onnxware.ButtonAPI.QM;

public class QMFoldout
{
    private Transform parent;
    private string headerText;
    private GameObject[] buttons;
    
    private GameObject Foldout;
    private FoldoutToggle FoldoutOptions;
    private GameObject ButtonHolder;
    
    public QMFoldout(string menuPath, string headerText, GameObject[] buttons)
    {
        if (!menuPath.Contains(ApiUtils.QuickMenu.name))
            this.parent = ApiUtils.QuickMenu.transform.Find(menuPath).transform;
        
            this.parent = GameObject.Find(menuPath).transform;
        
        this.headerText = headerText;
        this.buttons = buttons;
        
        Initialize();
    }

    private void Initialize()
    {
        Foldout = Object.Instantiate(GameObject.Find(DropdownPaths.QuickMenu_UserActions_Dropdown), parent, true);
        ButtonHolder = Object.Instantiate(GameObject.Find(DropdownPaths.QuickMenu_UserActions_AvatarButtons), parent, true);

        Foldout.name = $"{ApiUtils.Identifier}-Foldout-{ApiUtils.RandomNumbers()}";
        ButtonHolder.name = $"{ApiUtils.Identifier}-ButtonHolder-{ApiUtils.RandomNumbers()}";

        Foldout.GetComponentInChildren<TextMeshProUGUIEx>().text = headerText;
        FoldoutOptions = Foldout.GetComponentInChildren<FoldoutToggle>();
        FoldoutOptions._action.RemoveAllListeners();
        FoldoutOptions._toggle.onValueChanged.AddListener(new Action<bool>(x => onFoldout(x)));
        
        for (int i = 0; i < ButtonHolder.transform.childCount; i++)
            Object.Destroy(ButtonHolder.transform.GetChild(i).gameObject);
        
        foreach (GameObject button in buttons)
            button.transform.parent = ButtonHolder.transform;
        
    }
    private void onFoldout(bool isOn) => ButtonHolder.SetActive(isOn);
}
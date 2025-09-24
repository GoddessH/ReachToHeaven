using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeStat", menuName = "ScriptableObject/UpgradeStat")]
public class UpgradeStat : ScriptableObject
{
    //
    public UpgradeStatUIData UpgradeStatUIData;
    public CharacterStat UpgradeStatSystemData;
    public AdditionType AdditionType;
}

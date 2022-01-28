using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// d
/// </summary>
[System.Serializable]
public class InventorySlotModel
{
    [SerializeField]
    private CharacterGenerator characterGenerator;

    // �ش� �ε����� �����Դϴ�.
    public CharacterInfo getCharacterInfo(int index) => PlayerDatabase.Data(index);

    public void Create(string keyName)
    {
        if (characterGenerator == null) return;

        switch (keyName)
        {
            case "Gunslinger": characterGenerator.type = CharacterGeneratorFactory.Types.Gunslinger;break;
            case "Buster": characterGenerator.type = CharacterGeneratorFactory.Types.Buster; break;
            case "CannonShooter": characterGenerator.type = CharacterGeneratorFactory.Types.CannonShooter; break;
        }

        characterGenerator.Create();
    }
}

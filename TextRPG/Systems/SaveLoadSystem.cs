using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using TextRPG.Data;
using TextRPG.Models;

namespace TextRPG.Systems;

public class SaveLoadSystem
{
    // 저장 경로 및 파일 명
    private const string SaveFilePath = "save.json";
    
    // JSON 직렬화 옵션
    // 직렬화 의 : 객체 -> 문자열
    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 한글 지원
    };
    
    #region 저장 기능

    public static bool SaveGame(Player player, InventorySystem inventory)
    {
        try
        {
            // 1. 게임 객체 (클래스) -> DTO(DATA Transfer Object) 변환
            var saveData = new GameSaveData
            {
                Player = ConverToPlayerData(player),
                Inventory = ConverToItemData(inventory)
            };
            
            // 2. DTO 객체 -> JSON 문자열로 변환
            string jsonString = JsonSerializer.Serialize(saveData, jsonOptions);
            
            // 3. JSON 문자열 -> 파일로 저장
            File.WriteAllText(SaveFilePath, jsonString);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // Player -> PlayerData로 변환
    private static PlayerData ConverToPlayerData(Player player)
    {
        return new PlayerData
        {
            Name = player.Name,
            Job = player.Job.ToString(),
            Level = player.Level,
            CurrentHp = player.CurrentHp,
            MaxHp = player.MaxHp,
            CurrentMp = player.MaxMp,
            MaxMp = player.MaxMp,
            AttackPower = player.AttackPower,
            Defence = player.Defence,
            Gold = player.Gold,
            EquipedWeaponName = player.EquipmentWeapon?.Name,
            EquipedArmorName = player.EquipmentArmor?.Name,
        };
    }
    // Inventory -> ItemData로 변환
    private static List<ItemData> ConverToItemData(InventorySystem inventory)
    {
        var itemDataList = new List<ItemData>();

        for (int i = 0; i < inventory.Count; i++)
        {
            var item = inventory.GetItem(i);
            if (item == null) continue;

            var itemData = new ItemData
            {
                Name = item.Name
            };

            if (item is Equipment equipment)
            {
                itemData.ItemType = "Equipment";
                itemData.Slot = equipment.Slot.ToString();
            }
            else if (item is Consumable consumable)
            {
                itemData.ItemType = "Consumable";
            }
            
            itemDataList.Add(itemData);
        }
        
        return itemDataList;
    }
    
    #endregion  


}
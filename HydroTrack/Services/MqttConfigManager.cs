using HydroTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HydroTrack.Services
{
    public class MqttConfigManager
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public AppConfig Config { get; private set; } = new();

        public MqttConfigManager(string filePath)
        {
            _filePath = filePath;
            Load();
        }

        public void Load()
        {
            if (!File.Exists(_filePath))
            {
                Config = new AppConfig();
                Save(); // создаём файл с пустыми настройками
            }
            else
            {
                string json = File.ReadAllText(_filePath);
                Config = JsonSerializer.Deserialize<AppConfig>(json, _options) ?? new AppConfig();
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(Config, _options);
            File.WriteAllText(_filePath, json);
        }

        // ✅ Добавить или обновить топик
        public void AddOrUpdateTopic(string name, string topic)
        {
            Config.MqttSettings.Topics[name] = topic;
            Save();
        }

        // ✅ Удалить топик
        public bool RemoveTopic(string name)
        {
            bool removed = Config.MqttSettings.Topics.Remove(name);
            if (removed)
                Save();
            return removed;
        }

        // ✅ Получить все топики
        public Dictionary<string, string> GetAllTopics() =>
            new(Config.MqttSettings.Topics);

        // ✅ Получить топик по имени
        public string? GetTopic(string name)
        {
            return Config.MqttSettings.Topics.TryGetValue(name, out var topic)
                ? topic
                : null;
        }
    }
}

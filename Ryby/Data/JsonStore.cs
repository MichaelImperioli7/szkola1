using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static MauiApp7.MainPage;

namespace MauiApp7.Data
{
    internal class JsonStore
    {
        private readonly string _filepath;

        public JsonStore()
        {
            _filepath = Path.Combine(FileSystem.AppDataDirectory, "polowy.json");
        }
        public async Task SaveAllAsync(List<PolowRecord> records)
        {
            using var stream = File.Create(_filepath);
            await JsonSerializer.SerializeAsync(stream, records);
        }
        public async Task<List<PolowRecord>> GetRecordsAsync()
        {
            if (!File.Exists(_filepath))
                return new List<PolowRecord>();

            using var stream = File.OpenRead(_filepath);
            var data = await JsonSerializer.DeserializeAsync<List<PolowRecord>>(stream);
            return data ?? new List<PolowRecord>();
        }
    }
}

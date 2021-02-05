using Newtonsoft.Json;
using OpenSecureJournal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSecureJournal.Services
{
    public static class JournalFileService
    {
        public static async Task SaveJournal(string filePath, Journal journalToSave, string password)
        {
            var serialized = JsonConvert.SerializeObject(journalToSave);
            var encrypted = AESThenHMAC.SimpleEncryptWithPassword(serialized, password);
            await File.WriteAllTextAsync(filePath, encrypted);
        }

        public static async Task<Journal> OpenJournal(string filePath, string password)
        {
            var encrypted = await File.ReadAllTextAsync(filePath);
            var decrypted = AESThenHMAC.SimpleDecryptWithPassword(encrypted, password);

            var deserialized = JsonConvert.DeserializeObject<Journal>(decrypted);
            return deserialized;
        }
    }
}

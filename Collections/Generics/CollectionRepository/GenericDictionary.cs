using ConsoleTables;
using Pastel;

namespace Generics.CollectionRepository
{
    public class GenericDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> genericDictionary;

        public GenericDictionary(Dictionary<TKey, TValue> genericDictionary)
        { this.genericDictionary = genericDictionary; }

        public void CreateDictionary()
        {
            Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
            Console.WriteLine($"\nThe Dictionary of ({typeof(TKey).ToString().Replace("System.", "")}, {typeof(TValue).ToString().Replace("System.", "")}) is successfully created !!".Pastel(ConsoleColor.Cyan));

        }

        public ConsoleTable ReturnDictionaryAsTable()
        {
            Console.WriteLine($"\nAll the items in the dictionary are : ".Pastel(ConsoleColor.Yellow));

            ConsoleTable dictionaryTable = new ConsoleTable("S_No", "Key", "Value");

            for (int count = 1; count <= genericDictionary.Count(); count++)
                dictionaryTable.AddRow(count, genericDictionary.ElementAt(count - 1).Key, genericDictionary.ElementAt(count - 1).Value);

            return dictionaryTable;
        }

        public void RemoveItemFromDictionary(TKey deleteKey)
        {
            Console.WriteLine($"\n--------REMOVING--------".Pastel(ConsoleColor.Magenta));

            if (genericDictionary.Remove(deleteKey))
            {
                Console.WriteLine($"\n'{deleteKey}' is successfully deleted from the dictionary !!".Pastel(ConsoleColor.Cyan));
            }
            else
            {
                Console.WriteLine($"\n'{deleteKey}' is not present in the dictionary !!".Pastel(ConsoleColor.Red));
            }
        }

        public void AddItemToDictionary(TKey addKey, TValue addValue)
        {
            Console.WriteLine($"\n--------ADDING--------\n".Pastel(ConsoleColor.Magenta));

            genericDictionary.Add(addKey, addValue);

            Console.WriteLine($"\n'{addKey},{addValue}' is successfully added to the dictionary !!".Pastel(ConsoleColor.Cyan));
        }
    }
}

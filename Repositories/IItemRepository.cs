using projekt_web.Models;
using System.Collections.ObjectModel;

namespace projekt_web
{
    public interface IItemRepository
    {
        public int Create(Item item);
        public Item? Read(int Id);
        public int ReadBatch(ObservableCollection<Item> itemsObj, int batchSize, int offset);
        public int ReadAll(ObservableCollection<Item> itemsObj);
        public int SearchBatch(ObservableCollection<Item> itemsObj, int batchSize, int offset, string keyWord);
        public int SearchAll(ObservableCollection<Item> itemsObj, string keyWord);
        public int Update(Item item);
        public int Delete(int id);
        public int Clear();
    }
}

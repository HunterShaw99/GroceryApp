using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace GroceryApp.DataManager
{
    class DataMgr : Interfaces.ISubject
    {

        static volatile DataMgr instance = null;
        List<Interfaces.IObserver> observers;
        volatile List<Models.GroceryItem> groceryLIST = null;
        static readonly object lockObject = new object();

        DataMgr()
        {
            groceryLIST = new List<Models.GroceryItem>();
            observers = new List<Interfaces.IObserver>();
        }

        public static DataMgr GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DataMgr();
                    }
                }
            }
            return instance;
        }

        public void AddItem(Models.GroceryItem toAdd)
        {
            groceryLIST.Add(toAdd);
            NotifyObservers();
        }

        public void DeleteItem(Models.GroceryItem toDelete)
        {
            Models.GroceryItem deleted = null;
            var removed =
                from g in groceryLIST
                where g.ItemID.Equals(toDelete.ItemID)
                select g;

            foreach (var x in removed)
            {
                deleted = x;
            }
            groceryLIST.Remove(deleted);
            NotifyObservers();
        }

        public void UpdateItem(Guid itemID, string newName, decimal? newQuantity, string newCategory)
        {
            //Update the item
            var oldModel =
                from g in groceryLIST
                where g.ItemID.Equals(itemID)
                select g;

            foreach (var x in oldModel)
            {
                x.Name = newName;
                x.Quantity = newQuantity;
                x.Category = newCategory;
                x.CategoryNameField = newCategory + " - " + newName;
            }
            NotifyObservers();
        }

        public void RegisterObserver(Interfaces.IObserver o)
        {

            if (!observers.Contains(o)) {
                observers.Add(o);
            }
            
        }

        public void RemoveObserver(Interfaces.IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {

            foreach (Interfaces.IObserver o in observers)
            {
                o.Update(new List<Models.GroceryItem>(groceryLIST));
            }
            
        }

        public bool ListEmpty()
        {
            return groceryLIST.Count() == 0;
        }

        async public void SaveData()
        {

            String userPath = "";
            userPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String myFile = "names.txt";
            String pathFile = Path.Combine(userPath, myFile);
            Console.WriteLine(" path file is SAVING" + pathFile);
            string text = JsonConvert.SerializeObject(groceryLIST);
            await File.WriteAllTextAsync(pathFile, text);

        }

        public void LoadData()
        {

            String userPath = "";
            userPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String myFile = "names.txt";
            String pathFile = Path.Combine(userPath, myFile);
            Console.WriteLine(" path file is LOADING" + pathFile);
            try
            {
                string text = System.IO.File.ReadAllText(pathFile);
                groceryLIST = JsonConvert.DeserializeObject<List<Models.GroceryItem>>(text);
                NotifyObservers();
            } catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!!");
            }
                
        }

    }
}

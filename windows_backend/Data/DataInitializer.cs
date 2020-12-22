using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models;

namespace windows_backend.Data
{
    public class DataInitializer
    {
        private readonly Context _dbContext;

        public DataInitializer(Context dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {


                //Create items
                Item item1 = new Item("GSM");
                Item item2 = new Item("Oplader gsm");
                Item item3 = new Item("Zonnecreme");
                Item item4 = new Item("Zwembroek");
                Item item5 = new Item("Duikbril");
                Item item6 = new Item("Dafalgan");
                Item item7 = new Item("Zwemvliezen");
                Item item8 = new Item("Boeken");
                Item item9 = new Item("Ipad");
                for (int i = 1; i < 10; i++)
                {
                    _dbContext.Add($"item{i}");
                }
                _dbContext.SaveChanges();


                //Create categories
                Category cat1 = new Category("Elektronica", "Elektronische apparaten");
                Category cat2 = new Category("Handbagage", "Handbagage");
                Category cat3 = new Category("Toiletgerief", "Toiletgerief");
                Category cat4 = new Category("Zwwemgerief", "Alles om te zwemmen");
                Category cat5 = new Category("EHBO", "Medische zaken");
                _dbContext.Categories.Add(cat1);
                _dbContext.Categories.Add(cat2);
                _dbContext.Categories.Add(cat3);
                _dbContext.Categories.Add(cat4);
                _dbContext.Categories.Add(cat5);
                _dbContext.SaveChanges();


                //Create holidays
                Holiday holiday1 = new Holiday("Honeymoon", "Hawaii", "Huwelijksreis", new DateTime(2020, 3, 1));
                Holiday holiday2 = new Holiday("Hikingtrip", "Schotland", "Gaan wandelen met vrienden", new DateTime(2020, 5, 5));
                _dbContext.Holidays.Add(holiday1);
                _dbContext.Holidays.Add(holiday2);
                _dbContext.SaveChanges();

                //Create ItemTasks
                ItemTask itemtask1 = new ItemTask("Gsm nog opladen voor vertek");
                ItemTask itemstask2 = new ItemTask("Ipad nog opladen");
                _dbContext.Tasks.Add(itemtask1);
                _dbContext.Tasks.Add(itemstask2);
                _dbContext.SaveChanges();

                //Items aan category toevoegen
                //elektr items 1,2,9
                _dbContext.Categories.Where(c => c.Name == "Elektronica").SingleOrDefault().AddItem(item1);
                _dbContext.Categories.Where(c => c.Name == "Elektronica").SingleOrDefault().AddItem(item2);
                _dbContext.Categories.Where(c => c.Name == "Elektronica").SingleOrDefault().AddItem(item9);
                _dbContext.SaveChanges();

                //zwemgerief 4,5,7
                _dbContext.Categories.Where(c => c.Name == "Zwemgerief").SingleOrDefault().AddItem(item4);
                _dbContext.Categories.Where(c => c.Name == "Zwemgerief").SingleOrDefault().AddItem(item5);
                _dbContext.Categories.Where(c => c.Name == "Zwemgerief").SingleOrDefault().AddItem(item7);
                _dbContext.SaveChanges();

                //Toiletgerief 3
                _dbContext.Categories.Where(c => c.Name == "Toiletgerief").SingleOrDefault().AddItem(item3);
                _dbContext.SaveChanges();

                //Handbagage 8
                _dbContext.Categories.Where(c => c.Name == "Handbagage").SingleOrDefault().AddItem(item8);
                _dbContext.SaveChanges();

                //EHBO 6
                _dbContext.Categories.Where(c => c.Name == "EHBO").SingleOrDefault().AddItem(item6);
                _dbContext.SaveChanges();


            }
        }
    }
}


/* Xola Kota
 * email: xkota45@gmail.com
 * 
 * Bitcube
 * C# Assessment Project - Section 1
 * Console App (.NET Framework)
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store
{
    public interface IonlineStore
    {
        void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder);

        ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder);
        InventoryItemSummary GetInventoryItemSummary(ProductType stockType);
        InventorySummary GetInventorySummary();

    }
    public class Program
    {
        /*
         * returns true if the user entered an integer within the required range as input,
         * returns false otherwise.
         */
        static bool IsQueryValid(string query, int a, int b)
        {
            bool flag = false;
            if (int.TryParse(query, out int n) == true)
            {
                if (int.Parse(query) >= a && int.Parse(query) <= b)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /*
         * returns true if the user entered a double number > 0 as price input,
         * returns false if a word is entered e.g . "hi".
         */
        static bool IsPriceValid(string price)
        {
            bool flag = false;
            if (double.TryParse(price, out double n) == true)
            {
                if (double.Parse(price) > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /*
         * returns true if the user entered a integer number > 0 as quantity input,
         * returns false if a word is entered e.g . "hi".
         */
        static bool IsQuantityValid(string quantity)
        {
            bool flag = false;
            if (int.TryParse(quantity, out int n) == true)
            {
                if (int.Parse(quantity) > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("* * * Welcome to your online store * * *");
            OnlineStore myStore = new OnlineStore();
            Console.WriteLine("Online store created successfully...");
            Console.WriteLine(" ");



            string mainMenuQuery = "";
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("* * * Main Menu * * *");
                Console.WriteLine(" ");
                Console.WriteLine(" - Enter only integer corresponding to the queries below.");
                Console.WriteLine("[1] Inventory Summary.");
                Console.WriteLine("[2] Specific Inventory Summary.");
                Console.WriteLine("[3] Purchase Inventory.");
                Console.WriteLine("[4] Sell Inventory.");
                Console.WriteLine("[5] Exit.");

                Console.WriteLine(" ");
                Console.WriteLine("Waiting for main menu query>");
                mainMenuQuery = Console.ReadLine();
                while (IsQueryValid(mainMenuQuery, 1, 5) == false)
                {
                    Console.WriteLine("Invalid, waiting for valid main menu query>");
                    mainMenuQuery = Console.ReadLine();
                }

                if (int.Parse(mainMenuQuery) == 1)
                {
                    Console.WriteLine(" ");
                    myStore.GetInventorySummary().Display();
                }
                else if (int.Parse(mainMenuQuery) == 2)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("* * * Specific Inventory Summary * * *");
                    Console.WriteLine(" ");
                    Console.WriteLine(" - Enter only integer corresponding to the queries below.");
                    Console.WriteLine("[1] Display laptop inventory.");
                    Console.WriteLine("[2] Display tablet inventory.");
                    Console.WriteLine("[3] Display phone inventory.");

                    Console.WriteLine(" ");
                    Console.WriteLine("Waiting for inventory display query> ");
                    string query = Console.ReadLine();
                    while (IsQueryValid(query, 1, 3) == false)
                    {
                        Console.WriteLine("Invalid, waiting for valid inventory display query> ");
                        query = Console.ReadLine();
                    }

                    if (int.Parse(query) == 1)
                    {
                        myStore.GetInventoryItemSummary(myStore.GetLaptops().GetStockType()).Display();

                    }
                    else if (int.Parse(query) == 2)
                    {
                        myStore.GetInventoryItemSummary(myStore.GetTablets().GetStockType()).Display();

                    }
                    else if (int.Parse(query) == 3)
                    {
                        myStore.GetInventoryItemSummary(myStore.GetPhones().GetStockType()).Display();

                    }
                }
                else if (int.Parse(mainMenuQuery) == 3)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("* * * Purchase Inventory * * *");
                    Console.WriteLine(" ");
                    Console.WriteLine(" - Enter only integer corresponding to the queries below.");
                    Console.WriteLine("[1] Purchase laptop(s).");
                    Console.WriteLine("[2] Purchase tablet(s).");
                    Console.WriteLine("[3] Purchase phone(s).");

                    Console.WriteLine(" ");
                    Console.WriteLine("Waiting for purchase query> ");
                    string query = Console.ReadLine();
                    while (IsQueryValid(query, 1, 3) == false)
                    {
                        Console.WriteLine("Invalid, waiting for valid purchase query> ");
                        query = Console.ReadLine();
                    }

                    if (int.Parse(query) == 1)
                    {
                        Console.WriteLine("Enter price per laptop in rands: ");
                        string price = Console.ReadLine();
                        while (IsPriceValid(price) == false)
                        {
                            Console.WriteLine("Invalid, please enter price per laptop in rands: ");
                            price = Console.ReadLine();
                        }

                        Console.WriteLine("Enter number of laptops to purchase: ");
                        string quantity = Console.ReadLine();
                        while (IsQuantityValid(quantity) == false)
                        {
                            Console.WriteLine("Invalid, please enter number of laptops to purchase: ");
                            quantity = Console.ReadLine();
                        }
                        double price2 = double.Parse(price);
                        int quantity2 = int.Parse(quantity);
                        ProductsPurchaseOrder purchaseOrder = new ProductsPurchaseOrder(new ProductType("Laptop"), price2, quantity2);
                        myStore.AddProductsToInventory(purchaseOrder);
                        Console.WriteLine("Purchased laptop(s) added to inventory successfully...");

                    }
                    else if (int.Parse(query) == 2)
                    {
                        Console.WriteLine("Enter price per tablet in rands: ");
                        string price = Console.ReadLine();
                        while (IsPriceValid(price) == false)
                        {
                            Console.WriteLine("Invalid, please enter price per tablet in rands: ");
                            price = Console.ReadLine();
                        }

                        Console.WriteLine("Enter number of tablets to purchase: ");
                        string quantity = Console.ReadLine();
                        while (IsQuantityValid(quantity) == false)
                        {
                            Console.WriteLine("Invalid, please enter number of tablets to purchase: ");
                            quantity = Console.ReadLine();
                        }
                        double price2 = double.Parse(price);
                        int quantity2 = int.Parse(quantity);
                        ProductsPurchaseOrder purchaseOrder = new ProductsPurchaseOrder(new ProductType("Tablet"), price2, quantity2);
                        myStore.AddProductsToInventory(purchaseOrder);
                        Console.WriteLine("Purchased tablet(s) added to inventory successfully...");

                    }
                    else if (int.Parse(query) == 3)
                    {
                        Console.WriteLine("Enter price per phone in rands: ");
                        string price = Console.ReadLine();
                        while (IsPriceValid(price) == false)
                        {
                            Console.WriteLine("Invalid, please enter price per phone in rands: ");
                            price = Console.ReadLine();
                        }

                        Console.WriteLine("Enter number of phones to purchase: ");
                        string quantity = Console.ReadLine();
                        while (IsQuantityValid(quantity) == false)
                        {
                            Console.WriteLine("Invalid, please enter number of phones to purchase: ");
                            quantity = Console.ReadLine();
                        }
                        double price2 = double.Parse(price);
                        int quantity2 = int.Parse(quantity);
                        ProductsPurchaseOrder purchaseOrder = new ProductsPurchaseOrder(new ProductType("Phone"), price2, quantity2);
                        myStore.AddProductsToInventory(purchaseOrder);
                        Console.WriteLine("Purchased phone(s) added to inventory successfully...");

                    }

                }
                else if (int.Parse(mainMenuQuery) == 4)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("* * * Sell Inventory * * *");
                    Console.WriteLine(" ");
                    Console.WriteLine(" - Enter only integer corresponding to the queries below.");
                    Console.WriteLine("[1] Sell laptop(s).");
                    Console.WriteLine("[2] Sell tablet(s).");
                    Console.WriteLine("[3] Sell phone(s).");

                    Console.WriteLine(" ");
                    Console.WriteLine("Waiting for sell query> ");
                    string query = Console.ReadLine();
                    while (IsQueryValid(query, 1, 3) == false)
                    {
                        Console.WriteLine("Invalid, waiting for valid sell query> ");
                        query = Console.ReadLine();
                    }

                    if (int.Parse(query) == 1)
                    {

                        Console.WriteLine("Enter number of laptops to sell: ");
                        string quantity = Console.ReadLine();
                        while (IsQuantityValid(quantity) == false)
                        {
                            Console.WriteLine("Invalid, please enter number of laptops to sell: ");
                            quantity = Console.ReadLine();
                        }

                        int quantity2 = int.Parse(quantity);
                        ProductsSellOrder sellOrder = new ProductsSellOrder(new ProductType("Laptop"), quantity2);
                        myStore.SellProductsFromInventory(sellOrder).Display();


                    }
                    else if (int.Parse(query) == 2)
                    {
                        Console.WriteLine("Enter number of tablets to sell: ");
                        string quantity = Console.ReadLine();
                        while (IsQuantityValid(quantity) == false)
                        {
                            Console.WriteLine("Invalid, please enter number of tablets to sell: ");
                            quantity = Console.ReadLine();
                        }

                        int quantity2 = int.Parse(quantity);
                        ProductsSellOrder sellOrder = new ProductsSellOrder(new ProductType("Tablet"), quantity2);
                        myStore.SellProductsFromInventory(sellOrder).Display();

                    }
                    else if (int.Parse(query) == 3)
                    {
                        Console.WriteLine("Enter number of phones to sell: ");
                        string quantity = Console.ReadLine();
                        while (IsQuantityValid(quantity) == false)
                        {
                            Console.WriteLine("Invalid, please enter number of phones to sell: ");
                            quantity = Console.ReadLine();
                        }

                        int quantity2 = int.Parse(quantity);
                        ProductsSellOrder sellOrder = new ProductsSellOrder(new ProductType("Phone"), quantity2);
                        myStore.SellProductsFromInventory(sellOrder).Display();

                    }
                }


            } while (int.Parse(mainMenuQuery) != 5);

            Environment.Exit(2);


        }

    }

    /* 
     * The ProductType class returns the name of the type of inventory.
     * Example: Laptop, phone or tablet
     */
    public class ProductType
    {
        private string type;
        public ProductType(string type)
        {
            this.type = type;
        }
        public string GetType()
        {
            // return the name of the type of inventory.
            return type; 
        }
    }
    /*
     * The Stock class holds the information about a type of stork such its quantity and the total value 
     * of the stock currently available.
     * 
     */
    public class Stock
    {
        private ProductType productType;
        private int quantity;
        private double totalValueOfStock;
        

        public Stock(ProductType productType)
        {
            this.productType = productType;
            this.quantity = 0;
            this.totalValueOfStock = 0;
            
        }
        public Stock(ProductType productType, int quantity, float pricePerItem)
        {
            this.productType = productType;
            this.quantity = quantity;
            this.totalValueOfStock = quantity * pricePerItem;
        }
        
        public void Add(int quantity, double pricePerItem)
        {
            //During stock purchase, the quantity variable of a stork is increased by the number of items purchased.
            this.quantity += quantity;
            this.totalValueOfStock += quantity * pricePerItem;
        }

        public bool Sell(int quantity)
        {
            //During a stock sale, the quantity variable of a stork is decreased by the number of items sold.
            //If the quantity in inventory is less than the number of items being sold then false is returned.
            //if otherwise true is returned to indicate the transaction was successful.
            if (this.quantity < quantity || this.quantity == 0)
            {
                return false;
            }
            else
            {
                this.totalValueOfStock = this.totalValueOfStock - (this.GetAveragePricePerStock() * quantity);
                this.quantity -= quantity;
                return true;
            }
        }
        public ProductType GetStockType()
        {
            return productType;
        }
        public int GetQuantityOfStock()
        {
            return quantity;
        }
        public double GetAveragePricePerStock()
        {

            if (quantity == 0)
            {
                return 0;
            }
            else
            {
                return (totalValueOfStock / (double)quantity);
            }
        }
        public double GetTotalValueOfStock()
        {
            return this.totalValueOfStock;
        }
        //Printing on the Console the stock information.
        public void DisplayStock()
        {
            Console.WriteLine("Product type: " + this.GetStockType().GetType());
            Console.WriteLine("Quantity: " + this.GetQuantityOfStock());
            Console.WriteLine("Total value: R " + this.GetTotalValueOfStock());
            Console.WriteLine("Average price per product: R " + this.GetAveragePricePerStock());
        }

    }
    /*
     * The InventoryItemSummary class prints on the console the information about a specific type of
     * product in the inventory.
     * 
     */
    public class InventoryItemSummary
    {
        private Stock stockType;
        public InventoryItemSummary(Stock stockType)
        {
            this.stockType = stockType;
        }
        //Printing on the console the information about the type of stock/inventory.
        public void Display()
        {
            Console.WriteLine("* * * Specific Inventory Summary * * *");
            Console.WriteLine(" ");
            stockType.DisplayStock();
        }

    }
    /*
     * The ProductsPurchaseOrder class object is created when the store owner adds a product into the inventory.
     * This object has information about the type of item bought, its quantity and price per item.
     */
    public class ProductsPurchaseOrder
    {
        private ProductType productType;
        private double pricePerItem;
        private int quantity;

        public ProductsPurchaseOrder(ProductType productType, double pricePerItem, int quantity)
        {
            this.productType = productType;
            this.pricePerItem = pricePerItem;
            this.quantity = quantity;
        }
        public ProductType GetProductType()
        {
            return productType;
        }
        public double GetPricePerItem()
        {
            return pricePerItem;
        }
        public int GetQuantity()
        {
            return quantity;
        }

    }
    /*
     * The ProductsSellOrder class object is created when a customer buys from the store.
     * This object has information about the type of item being sold and its quantity.
     */
    public class ProductsSellOrder
    {
        private ProductType productType;
        private int quantity;

        public ProductsSellOrder(ProductType productType, int quantity)
        {
            this.productType = productType;
            this.quantity = quantity;
        }
        public ProductType GetProductType()
        {
            return productType;
        }
        public int GetQuantity()
        {
            return quantity;
        }

    }
    /*
     * The OnlineStore class holds information of all the types of stock in the inventory, such as laptops
     * ,tablets and phones
     * 
     * All the store owner admin methods/actions will be called in this class. 
     */
    public class OnlineStore : IonlineStore
    {
        private Stock laptops, tablets, phones;

        public OnlineStore()
        {
            this.laptops = new Stock(new ProductType("Laptop"));
            this.tablets = new Stock(new ProductType("Tablet"));
            this.phones = new Stock(new ProductType("Phone"));
        }
        public Stock GetLaptops()
        {
            return laptops;
        }
        public Stock GetTablets()
        {
            return tablets;
        }
        public Stock GetPhones()
        {
            return phones;
        }
        public void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder)
        {

            if (purchaseOrder.GetProductType().GetType() == this.laptops.GetStockType().GetType())
            {
                this.laptops.Add(purchaseOrder.GetQuantity(), purchaseOrder.GetPricePerItem());
            }
            else if (purchaseOrder.GetProductType().GetType() == this.tablets.GetStockType().GetType())
            {
                this.tablets.Add(purchaseOrder.GetQuantity(), purchaseOrder.GetPricePerItem());
            }
            else if (purchaseOrder.GetProductType().GetType() == this.phones.GetStockType().GetType())
            {
                this.phones.Add(purchaseOrder.GetQuantity(), purchaseOrder.GetPricePerItem());
            }

        }
        //returns an InventorySummary object that uses Display() method to print on the console. 
        public InventorySummary GetInventorySummary()
        {
            InventorySummary allInventory = new InventorySummary(this);
            return allInventory;
        }
        //returns an InventoryItemSummary object that uses Display() method to print on the console. 
        public InventoryItemSummary GetInventoryItemSummary(ProductType stockType)
        {
            InventoryItemSummary specificInventorySummary = null;
            if (stockType.GetType() == this.laptops.GetStockType().GetType())
            {
                specificInventorySummary = new InventoryItemSummary(this.laptops);
            }
            else if (stockType.GetType() == this.tablets.GetStockType().GetType())
            {
                specificInventorySummary = new InventoryItemSummary(this.tablets);
            }
            else if (stockType.GetType() == this.phones.GetStockType().GetType())
            {
                specificInventorySummary = new InventoryItemSummary(this.phones);
            }
            return specificInventorySummary;
        }
        //returns an ProductsSold object that uses Display() method to print on the console.
        public ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder)
        {
            ProductsSoldResult productsSoldResult = null;
            if (itemsSoldOrder.GetProductType().GetType() == this.laptops.GetStockType().GetType())
            {
                bool status = this.laptops.Sell(itemsSoldOrder.GetQuantity());
                productsSoldResult = new ProductsSoldResult(itemsSoldOrder, this, status);
            }
            else if (itemsSoldOrder.GetProductType().GetType() == this.tablets.GetStockType().GetType())
            {
                bool status = this.tablets.Sell(itemsSoldOrder.GetQuantity());
                productsSoldResult = new ProductsSoldResult(itemsSoldOrder, this, status);
            }
            else if (itemsSoldOrder.GetProductType().GetType() == this.phones.GetStockType().GetType())
            {
                bool status = this.phones.Sell(itemsSoldOrder.GetQuantity());
                productsSoldResult = new ProductsSoldResult(itemsSoldOrder, this, status);
            }
            return productsSoldResult;

        }


    }
    /*
     * The InventorySummary class prints on the console information about all the inventory currently in the
     * store when the Display() method is called on its object.
     */
    public class InventorySummary
    {
        private OnlineStore store;
        public InventorySummary(OnlineStore store)
        {
            this.store = store;
        }
        public void Display()
        {
            Console.WriteLine("* * * Inventory Summary * * *");
            Console.WriteLine(" ");
            Console.WriteLine("Total products in store: " + (store.GetLaptops().GetQuantityOfStock() + store.GetTablets().GetQuantityOfStock() + store.GetPhones().GetQuantityOfStock()));
            Console.WriteLine("Total value of all products in store: R " + (store.GetLaptops().GetTotalValueOfStock() + store.GetTablets().GetTotalValueOfStock() + store.GetPhones().GetTotalValueOfStock()));
            Console.WriteLine("____________________________________________________________________");
            store.GetLaptops().DisplayStock();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            store.GetTablets().DisplayStock();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            store.GetPhones().DisplayStock();

        }
    }
    /*
     * The ProductsSoldResult class object prints on the console the transction status for when a customer buys a item at
     * the store, when the Display() method is called.
     * 
     * The store owner will be notified if the transction is unsuccessful due to inventory shortage, or when the trans
     * action is successful due to enough products in the inventory.
     */
    public class ProductsSoldResult
    {
        private OnlineStore store;
        private ProductType productType;
        private int quantity;
        private bool status;

        public ProductsSoldResult(ProductsSellOrder productsSellOrder, OnlineStore store, bool status)
        {
            this.store = store;
            this.productType = productsSellOrder.GetProductType();
            this.quantity = productsSellOrder.GetQuantity();
            this.status = status;
        }

        public void Display()
        {
            Console.WriteLine(" ");
            Console.WriteLine("* * * Products Sold Result * * *");
            Console.WriteLine(" ");
            if (this.status == false)
            {
                Console.WriteLine("Product type: " + productType.GetType());
                Console.WriteLine("Quantity to sell: " + this.quantity);
                Console.WriteLine("Transaction above was unsuccessfull due to inventory shortage...");
            }
            else
            {
                Console.WriteLine("Product type: " + productType.GetType());
                Console.WriteLine("Quantity sold: " + this.quantity);
                if (productType.GetType() == store.GetLaptops().GetStockType().GetType())
                {
                    Console.WriteLine("Quantity remaining: " + store.GetLaptops().GetQuantityOfStock());
                }
                else if (productType.GetType() == store.GetTablets().GetStockType().GetType())
                {
                    Console.WriteLine("Quantity remaining: " + store.GetTablets().GetQuantityOfStock());
                }
                else if (productType.GetType() == store.GetPhones().GetStockType().GetType())
                {
                    Console.WriteLine("Quantity remaining: " + store.GetPhones().GetQuantityOfStock());
                }
                Console.WriteLine("Transaction above was successfull...");
            }
        }
    }


}

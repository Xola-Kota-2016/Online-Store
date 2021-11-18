
# Online-Store
C# Assessment Project

You've been tasked to implement a very basic Online Store using C#. In Phase 1 you will only implement the back-end of the store, a class library, not the front-end.

Project Specification:

Your store will only sell 3 items, Laptops, Tablets and Phones. Consumers of your store class library implementation should be able to do the following:

Get the current inventory summary for your whole store by calling the GetInventorySummary() method of your OnlineStore class (more details about this class below).
Get the current inventory summary for a specific product in your store by calling the GetInventoryItemSummary() method.
Add inventory to your store by calling the AddProductsToInventory() method.
Sell products from your store by calling the SellProductsFromInventory() method.
Your Store class should implement the following business rule:

You cannot sell products you don't have in stock. For instance, if you only have 1 phone in inventory, you cannot sell 2 phones.

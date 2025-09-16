using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(GroceryList), nameof(GroceryList))]
    public partial class GroceryListItemsViewModel : BaseViewModel
    {
        private readonly IGroceryListItemsService _groceryListItemsService;
        private readonly IProductService _productService;
        public ObservableCollection<GroceryListItem> MyGroceryListItems { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];

        [ObservableProperty]
        GroceryList groceryList = new(0, "None", DateOnly.MinValue, "", 0);

        public GroceryListItemsViewModel(IGroceryListItemsService groceryListItemsService, IProductService productService)
        {
            _groceryListItemsService = groceryListItemsService;
            _productService = productService;
        }

        private void Load(int id)
        {
            var items = _groceryListItemsService.GetAll();
            if (items != null)
            {
                foreach (var item in _groceryListItemsService.GetAllOnGroceryListId(id)) MyGroceryListItems.Add(item);

            }
            GetAvailableProducts();

        }
        private void GetAvailableProducts()
        {
            AvailableProducts.Clear();
            var allProducts = _productService.GetAll();
            if (allProducts == null) return;
            var existingProductIds = new HashSet<int>(MyGroceryListItems.Select(i => i.ProductId));

            foreach (var product in allProducts)
            {
                if (product == null) continue;
                if (product.Stock <= 0) continue;
                if (product.Id <= 0) continue;

                if (!existingProductIds.Contains(product.Id))
                {
                    AvailableProducts.Add(product);
                }
            }

        }

        partial void OnGroceryListChanged(GroceryList value)
        {
            if (value == null) return;
            if (value.Id == 0) return;
            Load(value.Id);
        }

        [RelayCommand]
        public async Task ChangeColor()
        {
            if (GroceryList == null) return;
            var parameter = new Dictionary<string, object> { { nameof(GroceryList), GroceryList } };
            await Shell.Current.GoToAsync(nameof(ChangeColorView), true, parameter);
        }
        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (product == null) return;
            if (GroceryList == null) return;

            var newItem = new GroceryListItem(0, GroceryList.Id, product.Id, 1);

            newItem.Product = product;

            var createdItem = _groceryListItemsService.Add(newItem);

            if (createdItem != null)
            {
                MyGroceryListItems.Add(createdItem);
            }
            else
            {

            }
            var toRemove = AvailableProducts.FirstOrDefault(p => p.Id == product.Id);
            if (toRemove != null)
            {
                AvailableProducts.Remove(toRemove);
            }
        }

    }
}


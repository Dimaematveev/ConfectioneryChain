using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryChain.DB
{
    public partial class BuyGood
    {
        public override string ToString()
        {
            return $"[{IDBuyGoods}]";
        }
    }
    public partial class Check
    {
        public override string ToString()
        {
            return $"[{ConfectioneryID}-{OrderID}-{CashierID}]";
        }
    }
    public partial class Customer
    {
        public override string ToString()
        {
            return $"[{Family} {Name} {PatronymicName}]";
        }
    }
    public partial class Confectionery
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
    public partial class DistributionOfEmployee
    {
        public override string ToString()
        {
            return $"[{Confectionery.ToString()}-{Employee.ToString()}-{Position.ToString()}]";
        }
    }
    public partial class Shop
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
    public partial class StaffWorkSchedule
    {
        public override string ToString()
        {
            return $"[{IDStaffWorkSchedule}]";
        }
    }
    public partial class Employee
    {
        public override string ToString()
        {
            return $"[{Family} {Name} {PatronymicName}]";
        }
    }
    public partial class FilingTheWarehouseConfectionery
    {
        public override string ToString()
        {
            return $"[{ConfectioneryID}-{GoodsID}]";
        }
    }
    public partial class GoodsInBuy
    {
        public override string ToString()
        {
            return $"[{IDGoodsInBuy}]";
        }
    }
    public partial class Good
    {
        public override string ToString()
        {
            return $"[{TypeOfGood.ToString()}-{Name}-{Unit.ToString()}]";
        }
    }
    public partial class OrderIssueOption
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
    public partial class Position
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
    public partial class TypeOfGood
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
    public partial class Unit
    {
        public override string ToString()
        {
            return $"[{Name}({MultipleValue})]";
        }
    }
    public partial class Order
    {
        public override string ToString()
        {
            return $"[{IDOrder}]";
        }
    }
    public partial class PriceList
    {
        public override string ToString()
        {
            return $"[{IDPriceList}]";
        }
    }
    public partial class PriceListRecipe
    {
        public override string ToString()
        {
            return $"[{PriceList.ToString()}-{Recipe.ToString()}]";
        }
    }
    public partial class RecipesInOrder
    {
        public override string ToString()
        {
            return $"[{PriceListRecipe.ToString()}-{HierararchyInRecipe.ToString()}]";
        }
    }
    public partial class ToppingInOrder
    {
        public override string ToString()
        {
            return $"[{ToppingInRecipe.ToString()}]";
        }
    }
    public partial class HierararchyInRecipe
    {
        public override string ToString()
        {
            return $"[{Recipe.ToString()}-{Hierarchy.ToString()}]";
        }
    }
    public partial class ItemInRecipe
    {
        public override string ToString()
        {
            return $"[{HierararchyInRecipe.ToString()}-{ItemInRecipeID}-{Good.ToString()}]";
        }
    }
    public partial class Recipe
    {
        public override string ToString()
        {
            return $"[{Name}-{Employee.ToString()}]";
        }
    }
    public partial class ToppingInRecipe
    {
        public override string ToString()
        {
            return $"[{Recipe.ToString()}-{Good.ToString()}]";
        }
    }
    public partial class FilingTheWarehouseShop
    {
        public override string ToString()
        {
            return $"[{Shop.ToString()}-{GoodsID}]";
        }
    }
    public partial class Invoice
    {
        public override string ToString()
        {
            return $"[{OrderID}]";
        }
    }
}

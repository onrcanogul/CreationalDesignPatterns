//Get instance from UserManager

UserManager userManager = UserManager.GetInstance;
UserManager _userManager = UserManager.GetInstance; // only 1 message on console

ProductManager productManager = ProductManager.GetInstance;
ProductManager _productManager = ProductManager.GetInstance; // only 1 message on console


//Single Responsibilty??????
#region First way
class UserManager
{
    private UserManager()
    {
        Console.WriteLine($"{nameof(UserManager)} has created.");    
    }
    static UserManager _userManager;
    public static UserManager GetInstance // can be method aswell
    {
        get { 
            if(_userManager == null)
                _userManager = new UserManager();

                return _userManager;
            }
    }
        
    
}
#endregion
#region Second Way
class ProductManager
{
    private ProductManager()
    {
        Console.WriteLine($"{nameof(ProductManager)} has created.");
    }
    static ProductManager()
    {
        _productManager = new ProductManager();
    }
    private static ProductManager _productManager;
    public static ProductManager GetInstance
    {
        get
        {
            return _productManager;
        }
    }
}

#endregion
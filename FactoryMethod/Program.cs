#region Bad Scenerio
//GarantiBank garantiBank = new("asd", "123");
//garantiBank.ConnectGaranti(); //we interrupt the coding process and focus on creating an instance 
////..
////..

//VakıfBank vakifBank = new(new() { Email = "asd@gmail.com", UserCode = "asd" }, "123");
//vakifBank.ValidateCredential();
//if(vakifBank.isAuthentication) // again we interrupt the coding process
//{
//    //..
//    //..
//}

//HalkBank halkBank = new("asd");
//halkBank.Password = "123";
#endregion


using System.Reflection;

GarantiBank? garantiBank = BankCreator.Create(BankTypes.GarantiBank) as GarantiBank;
VakifBank? vakifBank = BankCreator.Create(BankTypes.VakifBank) as VakifBank;
HalkBank? halkBank = BankCreator.Create(BankTypes.HalkBank) as HalkBank;

#region Abstract Product
interface IBank
{

}

#endregion

#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    public GarantiBank(string userCode, string password)
    {
        Console.WriteLine("GarantiBank");
        _userCode = userCode;
        _password = password;
    }
    public void ConnectGaranti() => Console.WriteLine($"{nameof(GarantiBank)} - Connected");
    public void SendMoney(int amount) => Console.WriteLine($"{amount} money sent");
}
class HalkBank : IBank
{
    string _userCode, _password;
    public HalkBank(string userCode)
    {
        Console.WriteLine("HalkBank");
        _userCode = userCode;
    }
    public string Password { set => _password = value; }
    public void Send(int amount, string accountNumber) => Console.WriteLine($"{amount} money sent.");
}
class CredentialVakifBank
{
    public string UserCode { get; set; }
    public string Email { get; set; }
}
class VakifBank : IBank
{
    string _userCode, _password, _email;
    public bool isAuthentication { get; set; }
    public VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine("VakifBank");
        _userCode = credential.UserCode;
        _email = credential.Email;
        _password = password;
    }
    public void ValidateCredential()
    {
        if (true)
            isAuthentication = true;

        isAuthentication = false;
    }

    public void SendMoneyToAccountNumber(int amount, string recpientName, string accountNumber) => Console.WriteLine($"{amount} money sent");

}
#endregion

#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion

#region Concrete Factory
class GarantiBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        GarantiBank garantiBank = new("asd", "123");
        garantiBank.ConnectGaranti();
        return garantiBank;
    }
}

class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        VakifBank vakifBank = new(new() { Email = "asd@gmail.com", UserCode = "asd" }, "123");
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}

class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new("asd123");
        halkBank.Password = "123";
        return halkBank;
    }
}

#endregion

#region Creator
enum BankTypes
{
    VakifBank, HalkBank, GarantiBank
}
class BankCreator
{
    static public IBank Create(BankTypes bankType)
    {
        //IBankFactory bankFactory = bankType switch
        //{
        //    BankTypes.VakifBank => new VakifBankFactory(),
        //    BankTypes.HalkBank => new HalkBankFactory(),
        //    BankTypes.GarantiBank => new GarantiBankFactory(),
        //    _ => throw new NotImplementedException()
        //};

        string factory = $"{bankType.ToString()}Factory";
        Type? type = Assembly.GetExecutingAssembly().GetType(factory);
        IBankFactory? bankFactory = Activator.CreateInstance(type) as IBankFactory;
        return bankFactory.CreateInstance();
    }
}
#endregion
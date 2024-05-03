
#region Bad Scenerio
//Computer comp1 = new();

//CPU cpu = new();
//comp1.CPU = cpu;

//RAM ram = new();
//comp1.RAM = ram;

//VideoCard videoCard = new();
//comp1.VideoCard = videoCard;
#endregion



ComputerCreator creator = new();
Computer asus = creator.CreateComputer(ComputerType.Asus); 

class Computer
{
    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }

    public Computer(ICPU cpu, IRAM ram, IVideoCard videoCard)
    {
        
    }
    public Computer()
    {
        
    }

}


#region Concrete Products
class CPU : ICPU
{
    
}

class RAM : IRAM
{

}

class VideoCard : IVideoCard
{

}
#endregion


#region Abstract Products

interface ICPU
{

}
interface IRAM
{

}
interface IVideoCard
{

}


#endregion


#region Abstract Factories
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion


#region Concrete Factories

class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU() =>  new CPU();
    public IRAM CreateRAM() => new RAM();
    public IVideoCard CreateVideoCard() => new VideoCard();
}

#endregion


#region Creator

enum ComputerType
{
    Asus
}
class ComputerCreator
{
    ICPU cpu;
    IRAM ram;
    IVideoCard videoCard;

    public Computer CreateComputer(ComputerType computerType)
    {
        IComputerFactory computerFactory = computerType switch
        {
            ComputerType.Asus  => new AsusFactory()
        };
        cpu = computerFactory.CreateCPU();
        ram = computerFactory.CreateRAM();
        videoCard = computerFactory.CreateVideoCard();

        return new(cpu, ram, videoCard);
    }
}

#endregion
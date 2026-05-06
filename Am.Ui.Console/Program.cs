

using Am.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");


// consterecteur par defaut

Plane p1 = new Plane();
p1.Capacity = 10;
p1.ManufactureDate = new DateTime(2020, 07, 07);
p1.PlaneType = PlaneType.Boing ;


// constructeur paramétré

Plane p2 = new Plane(300, new DateTime(2000, 07, 07), 222, PlaneType.Airbus);


Console.WriteLine(p2.ToString());
Console.WriteLine(p1.ToString());


//initializeur de Objet sans ordre de propriété 

Plane p3 = new Plane()
{
    Capacity = 200,
    PlaneId = 1,
    ManufactureDate = new DateTime(2010, 07, 07),
    PlaneType = PlaneType.Boing
};

Console.WriteLine(p3.ToString());



Passenger ck = new Passenger
{
    FirstName= "walid",
    LastName= "walid",

};



Console.WriteLine(ck.checkProfile2("walid", "walid"));

Passenger ck2 = new Passenger
{
    FirstName = "walid",
    LastName = "walid",
    
    Emailaddress = "walid@gmail.com",

};



Console.WriteLine(ck2.checkProfile2("walid", "walid", "walid@gmail.com"));
Console.WriteLine("***********test Passenger************");
ck2.PassengerType();

Console.WriteLine("***********test Traveller************");
Traveller T = new Traveller();
T.PassengerType();

Console.WriteLine("***********test Staff************");
Staff S = new Staff();
S.PassengerType();


using System.Collections.Concurrent;
using System.Reflection;

Console.WriteLine("***** Welcome to MyTypeViewer *****");
string typeName = "";

do
{
    Console.WriteLine("\nEnter a type name to evaluate");
    Console.Write("or enter Q to quit: ");

    typeName = Console.ReadLine();

    if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    try
    {
        Type type = Type.GetType(typeName);
        Console.WriteLine("");
        ListVariousStats(type);
        ListFields(type);
        ListProperties(type);
        ListMethods(type);
        ListInterfaces(type);
    }
    catch (Exception)
    {
        Console.WriteLine("Sorry, can't find type");
    }
} while (true);

static void ListMethods(Type type)
{
    Console.WriteLine("***** Methods ******");
    var methodNames = from method in type.GetMethods() select method.Name;
    foreach (string name in methodNames)
    {
        Console.WriteLine("-> {0}", name);
    }
    Console.WriteLine();
}

static void ListFields(Type type)
{
    Console.WriteLine("***** Fields *****");
    var fieldNames = from field in type.GetFields() select field.Name;
    foreach (string name in fieldNames)
    {
        Console.WriteLine("-> {0}", name);
    }
    Console.WriteLine();
}

static void ListProperties(Type type)
{
    Console.WriteLine("***** Properties *****");
    var propertyNames = from property in type.GetProperties() select property.Name;
    foreach(string name in propertyNames)
        Console.WriteLine("-> {0}", name);
    Console.WriteLine();
}

static void ListInterfaces(Type type)
{
    Console.WriteLine("***** Interfaces *****");
    var interfaces = from i in type.GetInterfaces() select i;
    foreach (Type interfaceType in interfaces)
        Console.WriteLine("-> {0}", interfaceType.Name);
}

static void ListVariousStats(Type type)
{
    Console.WriteLine("***** Various Statistics *****");
    Console.WriteLine("Base class is: {0}", type.BaseType);
    Console.WriteLine("Is type abstract? {0}", type.IsAbstract);
    Console.WriteLine("Is type sealed? {0}", type.IsSealed);
    Console.WriteLine("Is type generic? {0}", type.IsGenericType);
    Console.WriteLine("Is type a class type? {0}", type.IsClass);
    Console.WriteLine();
}
